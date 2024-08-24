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
using Flurl.Http;
using System.Data.SQLite;
using Dapper;
using System.Security.Cryptography;

namespace Hamster_Key_Generator
{
    public partial class FormMain : Form
    {
        private readonly Game[] _games;
        private static int _progressTime;
        private static ToolStripLabel _labelKeys;
        private static ToolStripLabel _labelRequest;
        private static NumericUpDown _delayNumericInput;
        private static ListBox _listBoxKeys;
        private static ProgressBar _progressBarMain;
        private static RichTextBox _richTextBoxLogs;


        public FormMain()
        {
            _progressTime = 0;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json");
            string jsonContent = File.ReadAllText(filePath);

            _games = JsonConvert.DeserializeObject<Game[]>(jsonContent);

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
            if (comboBoxGames.SelectedIndex < 0)
            {
                Log("Please select a game", Color.Orange);
                return;
            }

            Game selectedGame = null;
            // check exists game
            foreach (Game item in _games)
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

            buttonGenerate.Enabled = false;
            int countProcess = (int)numericUpDownProccess.Value;
            labelProccess.Text = $@"Processes: {countProcess}";
            Task[] processes = new Task[countProcess];
            for (int i = 0; i < countProcess; i++)
            {
                if (checkBoxProccessRandomDelay.Checked)
                {
                    await Task.Delay(new Random().Next(0, 5000));
                }

                processes[i] = Process(selectedGame, (int)numericUpDownCount.Value, "Proc_" + (i + 1));
            }

            await Task.WhenAll(processes);
            Log("All processes finished", Color.LimeGreen);
            buttonGenerate.Enabled = true;
        }

        private static async Task<string> Login(string token)
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
            return jsonObject["clientToken"]?.ToString();
        }

        private static async Task<int> Request(string clientToken, string promoId)
        {
            var url = "https://api.gamepromo.io/promo/register-event";

            var body = new
            {
                promoId,
                eventId = Guid.NewGuid().ToString(),
                eventOrigin = "undefined"
            };

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

        private static async Task<string> GenerateKey(string clientToken, string promoId)
        {
            var url = "https://api.gamepromo.io/promo/create-code";

            var body = new
            {
                promoId
            };

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

        private static string GenerateClientId()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Random random = new Random();
            string randomNumbers = string.Concat(Enumerable.Range(0, 19).Select(_ => random.Next(10)));
            return $"{timestamp}-{randomNumbers}";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshStatics();
            timer1.Start();
            comboBoxGames.Items.Clear();
            for (int i = 0; i < _games.Count(); i++)
            {
                comboBoxGames.Items.Add(_games[i].name);
            }
        }

        private static void Log(string text, Color color = default(Color), string section = null)
        {
            DateTime now = DateTime.Now;
            string formattedTime = now.ToString("HH:mm:ss");
            _richTextBoxLogs.AppendText("[" + formattedTime + "]");
            Color originalColor = _richTextBoxLogs.SelectionColor;
            if (section != null)
            {
                _richTextBoxLogs.AppendText("(");
                _richTextBoxLogs.SelectionColor = GetColorFromText(section);
                _richTextBoxLogs.AppendText(section);
                _richTextBoxLogs.SelectionColor = originalColor;
                _richTextBoxLogs.AppendText(")");
            }

            _richTextBoxLogs.AppendText(" ");
            _richTextBoxLogs.SelectionColor = color.IsKnownColor ? color : Color.White;

            _richTextBoxLogs.AppendText(text + "\n");
            _richTextBoxLogs.SelectionColor = originalColor;
            _richTextBoxLogs.ScrollToCaret();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (listBoxKeys.SelectedItem != null)
            {
                Clipboard.SetText(listBoxKeys.SelectedItem.ToString());
                Log("Item copied to clipboard: " + listBoxKeys.SelectedItem, Color.Yellow);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_progressTime > 0)
            {
                int value = 100 / (_progressTime / timer1.Interval);
                if (progressBarMain.Value + value < 100)
                {
                    progressBarMain.Value += value;
                }
            }
        }

        private static int AddKeyToDatabase(string key, string platform)
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

        private static async Task Process(Game g, int keyCount, string processName)
        {
            for (int keyNumber = 1; keyNumber <= keyCount; keyNumber++)
            {
                Log("Start generating key " + keyNumber, section: processName);
                string clientToken;
                try
                {
                    clientToken = await Login(g.appToken);
                    Log("Client token: " + clientToken, section: processName);
                }
                catch
                {
                    Log("Login failed", Color.Red, section: processName);
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
                Log("Sending requests ...", Color.Cyan, section: processName);
                while (response != 200)
                {
                    int delays = g.eventsDelay + rand.Next(-2000, 2000) + surplusDelay;
                    if (delays < _delayNumericInput.Value)
                    {
                        delays = (int)_delayNumericInput.Value + rand.Next(0, 1000);
                    }

                    if (_progressBarMain.Value == 0 || _progressBarMain.Value == 100)
                    {
                        _progressBarMain.Value = 0;
                        _progressTime = delays;
                    }

                    Log("Request " + attempts + " (" + delays.ToString("N0") + ") ...", section: processName);
                    _labelRequest.Text = $@"Last request: {attempts}";
                    attempts++;
                    await Task.Delay(delays);
                    try
                    {
                        response = await Request(clientToken, g.promoId);
                    }
                    catch
                    {
                        Log("Http error", Color.Red, section: processName);
                        continue;
                    }

                    if (response == 2)
                    {
                        Log("Session for client not valid", Color.Red, section: processName);
                        restartClient = true;
                        break;
                    }
                    else if (response == 3)
                    {
                        repeatedSuccessCount = 0;
                        Log("Requests are very fast - Increase delay", Color.Orange, section: processName);
                        surplusDelay += 2000;
                    }
                    else if (response == 400)
                    {
                        repeatedSuccessCount = 0;
                        Log("Undefined error", section: processName);
                    }
                    else if (response == 1)
                    {
                        repeatedSuccessCount++;
                        if (repeatedSuccessCount >= 3)
                        {
                            Log("Delay decreased", Color.Orange, section: processName);
                            surplusDelay -= 1000;
                            repeatedSuccessCount = 0;
                        }
                    }

                    _progressBarMain.Value = 100;
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
                    key = await GenerateKey(clientToken, g.promoId);
                }
                catch (Exception)
                {
                    Log("Failed to generate key", Color.Red, section: processName);
                    keyNumber--;
                    continue;
                }

                if (string.IsNullOrEmpty(key))
                {
                    Log("Failed to generate key", Color.Red, section: processName);
                    keyNumber--;
                    continue;
                }

                switch (AddKeyToDatabase(key, g.platform))
                {
                    case 0:
                        Log("Failed saving key on database", Color.Red, section: processName);
                        break;
                    case 100:
                        Log("Key exists!", Color.Pink, section: processName);
                        break;
                }

                _listBoxKeys.Items.Add(key);
                _listBoxKeys.TopIndex = _listBoxKeys.Items.Count - 1;
                _labelKeys.Text = $@"Keys: " + _listBoxKeys.Items.Count;

                Log("Key successfully generated: " + key, Color.LimeGreen, section: processName);
            }

            Log("Process finished", Color.Lime, section: processName);
        }

        private void comboBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Game selectedGame = null;
            // check exists game
            foreach (Game item in _games)
            {
                if (item.name == comboBoxGames.Text)
                {
                    selectedGame = item;
                }
            }

            if (selectedGame == null)
            {
                return;
            }

            numericUpDownMinimumDelay.Value = selectedGame.eventsDelay;
            RefreshStatics();
        }

        private void RefreshStatics()
        {
            _labelKeys = labelKeys;
            _labelRequest = labelRequest;
            _delayNumericInput = numericUpDownMinimumDelay;
            _listBoxKeys = listBoxKeys;
            _progressBarMain = progressBarMain;
            _richTextBoxLogs = richTextBoxLogs;
        }

        private static Color GetColorFromText(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input + "artariya"));
                int hue = BitConverter.ToUInt16(hash, 0) % 360;

                return HslToRgb(hue, 1.0, 0.5);
            }
        }

        private static Color HslToRgb(double h, double s, double l)
        {
            double c = (1.0 - Math.Abs(2.0 * l - 1.0)) * s;
            double x = c * (1.0 - Math.Abs((h / 60.0) % 2.0 - 1.0));
            double m = l - c / 2.0;

            double r, g, b;
            if (h < 60)
            {
                r = c;
                g = x;
                b = 0;
            }
            else if (h < 120)
            {
                r = x;
                g = c;
                b = 0;
            }
            else if (h < 180)
            {
                r = 0;
                g = c;
                b = x;
            }
            else if (h < 240)
            {
                r = 0;
                g = x;
                b = c;
            }
            else if (h < 300)
            {
                r = x;
                g = 0;
                b = c;
            }
            else
            {
                r = c;
                g = 0;
                b = x;
            }

            return Color.FromArgb((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
        }
    }
}