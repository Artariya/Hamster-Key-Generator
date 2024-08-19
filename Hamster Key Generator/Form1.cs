using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Drawing;
using Flurl;
using Flurl.Http;
using System.Data.SQLite;
using Dapper;


namespace Hamster_Key_Generator
{
    public partial class FormMain : Form
    {
        Game[] Games;
        Game selectedGame = null;
        int progressTime = 0;

        public FormMain()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json");
            string jsonContent = File.ReadAllText(filePath);

            Games = JsonConvert.DeserializeObject<Game[]>(jsonContent);

            using (var connection = new SQLiteConnection("Data Source=keys.db;Version=3;"))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS keys (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        key TEXT UNIQUE NOT NULL,
                        platform TEXT NOT NULL
                    );";

                connection.Execute(createTableQuery);

                connection.Close();
            }

            InitializeComponent();
        }

        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (selectedGame != null)
            {
                Log("Another proccess is runing!", Color.Red);
                return;
            }
            // check exists game
            foreach (Game item in Games)
            {
                if (item.name == comboBoxGames.Text)
                {
                    selectedGame = item;
                }
            }

            if (selectedGame == null)
            {
                Log("Selected game not founded!", Color.Orange);
                return;
            }

            // start generation
            numericUpDownMinimumDelay.Value = selectedGame.eventsDelay;
            for (int keyNumber = 1; keyNumber <= numericUpDownCount.Value; keyNumber++)
            {
                Log("Start generating key " + keyNumber);
                string clientToken = null;
                try
                {
                    clientToken = await Login(selectedGame.appToken);
                    Log("Client token: " + clientToken);
                }
                catch
                {
                    Log("Login failed", Color.Red);
                    await Task.Delay(new Random().Next(0, 3000) + 5000);
                    keyNumber--;
                    continue;
                }

                int attempts = 1;
                int response = 0;
                int surplusDelay = 0;
                bool restartClient = false;
                int repeatedSuccessCount = 0;
                Random rand = new Random();
                Log("Sending requests ...", Color.Cyan);
                while (response != 200)
                {

                    int delays = selectedGame.eventsDelay + rand.Next(-2000, 2000) + surplusDelay;
                    if (delays < numericUpDownMinimumDelay.Value)
                    {
                        delays = (int)numericUpDownMinimumDelay.Value + rand.Next(0, 1000);
                    }
                    initProgress();
                    Log("Request " + attempts + " (" + delays.ToString() + ") ...");
                    attempts++;
                    progressTime = delays;
                    await Task.Delay(delays);
                    try
                    {
                        response = await Request(clientToken, selectedGame.promoId);
                    }
                    catch
                    {
                        Log("Http error", Color.Red);
                        continue;
                    }
                    if (response == 2)
                    {
                        repeatedSuccessCount = 0;
                        Log("Session for client not valid", Color.Red);
                        restartClient = true;
                        break;
                    }
                    else if (response == 3)
                    {
                        repeatedSuccessCount = 0;
                        Log("Requests are very fast - Increase delay", Color.Orange);
                        surplusDelay += 2000;
                    }
                    else if (response == 400)
                    {
                        repeatedSuccessCount = 0;
                        Log("Undefined error");
                    }
                    else if (response == 1)
                    {
                        repeatedSuccessCount++;
                        if (repeatedSuccessCount >= 3)
                        {
                            Log("Delay decreased", Color.Orange);
                            surplusDelay -= 1000;
                            repeatedSuccessCount = 0;
                        }
                    }
                    progressBarMain.Value = 100;
                }
                if (restartClient)
                {
                    keyNumber--;
                    continue;
                }

                // get key
                string key;
                try
                {
                    key = await GenerateKey(clientToken, selectedGame.promoId);
                }
                catch (Exception)
                {
                    Log("Failed to generate key", Color.Red);
                    keyNumber--;
                    continue;
                }

                if (string.IsNullOrEmpty(key))
                {
                    Log("Failed to generate key", Color.Red);
                    keyNumber--;
                    continue;
                }
                switch (AddKeyToDatabase(key, selectedGame.platform))
                {
                    case 0:
                        Log("Failed saving key on database", Color.Red);
                        break;
                    case 100:
                        Log("Key exists!", Color.Pink);
                        break;
                }
                listBoxKeys.Items.Add(key);
                listBoxKeys.TopIndex = listBoxKeys.Items.Count - 1;

                Log("Key successfully generated: " + key, Color.LimeGreen);
            }
            Log("Proccess finished", Color.Lime);
            selectedGame = null;
        }

        public static async Task<string> Login(string token)
        {
            var url = "https://api.gamepromo.io/promo/login-client";

            var requestHeaders = new HttpRequestMessage(HttpMethod.Post, url);
            // headers
            /*requestHeaders.Headers.Add("Content-Type", "application/json");*/

            // body
            var body = new
            {
                appToken = token,
                clientId = GenerateClientId(),
                clientOrigin = "deviceid"
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            requestHeaders.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var response = await client.SendAsync(requestHeaders);
            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(responseBody);
            return jsonObject["clientToken"].ToString();
        }

        public static async Task<int> Request(string clientToken, string promoId)
        {
            var url = "https://api.gamepromo.io/promo/register-event";

            var body = new
            {
                promoId = promoId,
                eventId = Guid.NewGuid().ToString(),
                eventOrigin = "undefined"
            };

            try
            {
                var response = await url
                    .WithOAuthBearerToken(clientToken)
                    .AllowHttpStatus("4xx")
                    .PostJsonAsync(body).ReceiveString();

                var jsonObject = JObject.Parse(response);

                if (jsonObject["hasCode"] != null)
                {
                    return jsonObject.Value<bool>("hasCode") ? 200 : 1;
                }
                else if (jsonObject["error_code"] != null)
                {
                    switch (jsonObject["error_code"].ToString().ToLower())
                    {
                        case "unauthorized":
                            return 2;
                        case "toomanyregister":
                            return 3;
                    }
                }
                return 400;
            }
            catch
            {
                throw;
            }
        }

        public static async Task<string> GenerateKey(string clientToken, string promoId)
        {
            var url = "https://api.gamepromo.io/promo/create-code";

            var body = new
            {
                promoId = promoId
            };

            try
            {
                var response = await url
                        .WithOAuthBearerToken(clientToken)
                        .AllowHttpStatus("4xx")
                        .PostJsonAsync(body).ReceiveString();

                JObject jsonObject = JObject.Parse(response);
                if (jsonObject["promoCode"] != null)
                {
                    return jsonObject["promoCode"].ToString();
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public static string GenerateClientId()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Random random = new Random();
            string randomNumbers = string.Concat(Enumerable.Range(0, 19).Select(_ => random.Next(10)));
            return $"{timestamp}-{randomNumbers}";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            comboBoxGames.Items.Clear();
            for (int i = 0; i < Games.Count(); i++)
            {
                comboBoxGames.Items.Add(Games[i].name);
            }
        }

        private void Log(string text, Color color = default(Color))
        {
            DateTime now = DateTime.Now;
            string formattedTime = now.ToString("HH:mm:ss");
            richTextBoxLogs.AppendText("[" + formattedTime + "] ");
            Color originalColor = richTextBoxLogs.SelectionColor;
            if (color.IsKnownColor)
            {
                richTextBoxLogs.SelectionColor = color;
            }
            else
            {
                richTextBoxLogs.SelectionColor = Color.White;
            }
            richTextBoxLogs.AppendText(text + "\n");
            richTextBoxLogs.SelectionColor = originalColor;
            richTextBoxLogs.ScrollToCaret();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (listBoxKeys.SelectedItem != null)
            {
                Clipboard.SetText(listBoxKeys.SelectedItem.ToString());
                Log("Item copied to clipboard: " + listBoxKeys.SelectedItem.ToString(), Color.Yellow);
            }
            else
            {
                Log("No item selected to copy.", Color.Yellow);
            }
        }

        private void buttonCopyAll_Click(object sender, EventArgs e)
        {
            StringBuilder allItems = new StringBuilder();
            foreach (var item in listBoxKeys.Items)
            {
                allItems.AppendLine(item.ToString());
            }
            Clipboard.SetText(allItems.ToString());
            Log("All items copied to clipboard.", Color.Yellow);
        }

        private void initProgress()
        {
            progressBarMain.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressTime > 0)
            {
                int value = 100 / (progressTime / timer1.Interval);
                if (progressBarMain.Value + value < 100)
                {
                    progressBarMain.Value += value;
                }
            }
        }

        int AddKeyToDatabase(string key, string platform)
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=keys.db;Version=3;"))
                {
                    connection.Open();

                    string checkKeyQuery = "SELECT COUNT(1) FROM keys WHERE key = @Key;";
                    int keyExists = connection.QuerySingle<int>(checkKeyQuery, new { Key = key });

                    if (keyExists > 0)
                    {

                        return 100;
                    }

                    string insertQuery = "INSERT INTO keys (key, platform) VALUES (@Key, @Platform);";
                    var result = connection.Execute(insertQuery, new { Key = key, Platform = platform });

                    return result > 0 ? 200 : 0;
                }
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message, Color.Red);
                return 0;
            }
        }
    }
}
