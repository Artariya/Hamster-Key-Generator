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
using System.Net;
using MihaZupan;
using System.Media;
using System.Diagnostics;

namespace Hamster_Key_Generator
{
    public partial class FormMain : Form
    {
        private Game[] _games;
        private static int _progressTime;
        private static ToolStripLabel _labelKeys;
        private static ToolStripLabel _labelRequest;
        private static NumericUpDown _delayNumericInput;
        private static ListBox _listBoxKeys;
        private static ToolStripProgressBar _progressBarMain;
        private static RichTextBox _richTextBoxLogs;
        private static RadioButton _radioNoProxy;
        private static RadioButton _radioAutoProxy;
        private static NotifyIcon _notifyIconMain;
        private static ListBox _listBoxProxies;
        private static string _lastProxy;
        private static string _selectedProxy;
        private static NumericUpDown _timeOut;
        private static CheckBox _removeBadProxies;


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

            // Start generation
            if (SelectProxy())
            {
                Log($"Proxy selected: {_selectedProxy}", Color.LightPink, "Proxy");
            }
            notifyIconMain.Text = selectedGame.name;
            buttonGenerate.Enabled = false;
            numericUpDownCount.Enabled = false;
            numericUpDownProccess.Enabled = false;
            comboBoxGames.Enabled = false;
            checkBoxProccessRandomDelay.Enabled = false;
            buttonUpdate.Enabled = false;
            int countProcess = (int)numericUpDownProccess.Value;
            labelProccess.Text = $@"Processes: {countProcess}";
            Task[] processes = new Task[countProcess];
            for (int i = 0; i < countProcess; i++)
            {
                if (checkBoxProccessRandomDelay.Checked)
                {
                    await Task.Delay(new Random().Next(0, 5000));
                }

                processes[i] = RunProcess(selectedGame, (int)numericUpDownCount.Value, "Proc_" + (i + 1));
            }

            await Task.WhenAll(processes);
            Log("All processes finished", Color.LimeGreen);
            notifyIconMain.ShowBalloonTip(5000, selectedGame.name + " was finished", "Now you have " + listBoxKeys.Items.Count + " keys.", ToolTipIcon.Info);
            buttonGenerate.Enabled = true;
            numericUpDownCount.Enabled = true;
            numericUpDownProccess.Enabled = true;
            comboBoxGames.Enabled = true;
            checkBoxProccessRandomDelay.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private static async Task<string> Login(string token)
        {
            var url = "https://api.gamepromo.io/promo/login-client";

            var body = new
            {
                appToken = token,
                clientId = GenerateClientId(),
                clientOrigin = "deviceid"
            };

            var response = await GetFlurlClient()
                .Request(url)
                .AllowHttpStatus("4xx")
                .PostJsonAsync(body).ReceiveString();

            JObject jsonObject = JObject.Parse(response);
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

            var response = await GetFlurlClient()
                .Request(url)
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

            var response = await GetFlurlClient()
                .Request(url)
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
            // load proxies
            if (File.Exists("proxies.txt"))
            {
                foreach (var item in File.ReadAllLines("proxies.txt"))
                {
                    listBoxProxies.Items.Add(item);
                }
            }
            RefreshStatics();
            timer1.Start();
            LoadGames();
            // Load Settings
            // Proxy Settings
            switch (IniData.ReadData("proxy", "type"))
            {
                case "auto":
                    radioButtonProxy2.Checked = true;
                    break;
                default:
                    radioButtonProxy1.Checked = true;
                    break;
            }
            checkBoxRemoveBadProxy.Checked = IniData.ReadData("proxy", "remove_bad_proxies") == "yes";
            numericUpDownTimeOut.Value = int.Parse(IniData.ReadData("proxy", "timeout", "10"));
            // Delay Settings
            checkBoxProccessRandomDelay.Checked = IniData.ReadData("delay", "random_proccess") == "yes";
        }

        private void LoadGames()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json");
            string jsonContent = File.ReadAllText(filePath);
            _games = JsonConvert.DeserializeObject<Game[]>(jsonContent);

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
            if (listBoxKeys.Items.Count > 0)
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
        }

        private void buttonCopyAll_Click(object sender, EventArgs e)
        {
            if (listBoxKeys.Items.Count > 0)
            {
                StringBuilder allItems = new StringBuilder();
                foreach (var item in listBoxKeys.Items)
                {
                    allItems.AppendLine(item.ToString());
                }

                Clipboard.SetText(allItems.ToString());
                Log("All items copied to clipboard.", Color.Yellow);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_progressTime > 0)
            {
                int value = 100 / (_progressTime / timer1.Interval);
                if (toolStripProgressBarMain.Value + value < 100)
                {
                    toolStripProgressBarMain.Value += value;
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
                SystemSounds.Hand.Play();
                Log("Error: " + ex.Message, Color.Red, "DataBase");
                return 0;
            }
        }

        private static async Task RunProcess(Game g, int keyCount, string processName)
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
                catch (Exception e)
                {
                    SystemSounds.Exclamation.Play();
                    Log("Login failed: " + e.Message, Color.Red, section: processName);
                    RemoveBadProxy();
                    if (SelectProxy())
                    {
                        Log($"Proxy switched to: {_selectedProxy}", Color.LightPink, "Proxy");
                    }
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
                    catch (Exception e)
                    {
                        SystemSounds.Exclamation.Play();
                        Log("Http error: " + e.Message, Color.Red, section: processName);
                        RemoveBadProxy();
                        if (SelectProxy())
                        {
                            Log($"Proxy switched to: {_selectedProxy}", Color.LightPink, "Proxy");
                        }
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
            _progressBarMain = toolStripProgressBarMain;
            _richTextBoxLogs = richTextBoxLogs;
            _radioNoProxy = radioButtonProxy1;
            _radioAutoProxy = radioButtonProxy2;
            _notifyIconMain = notifyIconMain;
            _listBoxProxies = listBoxProxies;
            _timeOut = numericUpDownTimeOut;
            _removeBadProxies = checkBoxRemoveBadProxy;
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

        private void radioButtonProxy2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButtonProxy3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save Setting
            // Proxt Settings
            string proxyType = "no-proxy";
            if (radioButtonProxy2.Checked)
            {
                proxyType = "auto";
            }
            IniData.WriteData("proxy", "type", proxyType);
            IniData.WriteData("proxy", "remove_bad_proxies", checkBoxRemoveBadProxy.Checked ? "yes" : "no");
            IniData.WriteData("proxy", "timeout", ((int)numericUpDownTimeOut.Value).ToString());
            // Delay Settings
            IniData.WriteData("delay", "random_proccess", checkBoxProccessRandomDelay.Checked ? "yes" : "no");
        }

        private static IFlurlClient GetFlurlClient()
        {
            var httpClientHandler = new HttpClientHandler();
            if (_listBoxProxies.Items.Count > 0 && _radioAutoProxy.Checked)
            {
                string[] parts = _selectedProxy.Split(new char[] { ':', '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts[0] == "socks5")
                {
                    httpClientHandler.Proxy = new HttpToSocks5Proxy(parts[1], int.Parse(parts[2]));
                    httpClientHandler.UseProxy = true;
                }
                else if (parts[0] == "http")
                {
                    string proxyUri = _selectedProxy;
                    httpClientHandler.Proxy = new WebProxy(proxyUri);
                    httpClientHandler.UseProxy = true;
                }
            }
            var httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds((int)_timeOut.Value);
            var flurlClient = new FlurlClient(httpClient);
            return flurlClient;
        }

        private static void RemoveBadProxy()
        {
            if (!_removeBadProxies.Checked)
            {
                return;
            }
            string[] parts = _selectedProxy.Split(new char[] { ':', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts[1] == "127.0.0.1")
            {
                return;
            }
            for (int i = 0; i < _listBoxProxies.Items.Count; i++)
            {
                if (_listBoxProxies.Items[i].ToString() == _selectedProxy)
                {
                    _listBoxProxies.Items.RemoveAt(i);
                    break;
                }
            }
            SaveProxies();

        }
        private static bool SelectProxy()
        {
            if (_listBoxProxies.Items.Count > 0)
            {
                Random random = new Random();
                string randomItem = null;
                while (randomItem == null || randomItem == _lastProxy)
                {
                    int randomIndex = random.Next(_listBoxProxies.Items.Count);
                    randomItem = _listBoxProxies.Items[randomIndex].ToString();
                    if (_listBoxProxies.Items.Count == 1)
                    {
                        break;
                    }
                }
                _selectedProxy = randomItem;
                _lastProxy = randomItem;
                return true;
            }
            return false;
        }

        private void buttonExportKeys_Click(object sender, EventArgs e)
        {
            if (listBoxKeys.Items.Count > 0)
            {
                SaveFileDialog sf = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    DefaultExt = "txt",
                    FileName = "keys(" + DateTime.Now.ToString("yy-MM-dd-HH-mm") + ").txt",
                    Title = "Save your keys"
                };
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string[] items = new string[listBoxKeys.Items.Count];
                    for (int i = 0; i < listBoxKeys.Items.Count; i++)
                    {
                        items[i] = listBoxKeys.Items[i].ToString();
                    }
                    File.WriteAllLines(sf.FileName, items);
                    MessageBox.Show("Key successfully saved.", "Keys saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible)
            {
                this.Focus();
            }
        }

        private void buttonGithub_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/artariya",
                UseShellExecute = true
            });
        }

        private void radioButtonProxy1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void buttonProxyAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxProxyHost.Text)
                && !String.IsNullOrEmpty(textBoxProxyPort.Text)
                && comboBoxProxyType.SelectedIndex >= 0)
            {
                string proxy;
                switch (comboBoxProxyType.Text.ToLower())
                {
                    case "socks5":
                        proxy = "socks5://";
                        break;
                    case "http":
                        proxy = "http://";
                        break;
                    default:
                        MessageBox.Show("Select a proxy type", "select type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                proxy += textBoxProxyHost.Text;
                proxy += ":";
                proxy += textBoxProxyPort.Text;

                listBoxProxies.Items.Add(proxy);
                SaveProxies();
            }
        }

        private void buttonProxyRemove_Click(object sender, EventArgs e)
        {
            if (listBoxProxies.SelectedIndex >= 0)
            {
                listBoxProxies.Items.RemoveAt(listBoxProxies.SelectedIndex);
            }
            SaveProxies();
        }

        private static void SaveProxies()
        {
            using (StreamWriter writer = new StreamWriter("proxies.txt", false))
            {
                foreach (var item in _listBoxProxies.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            string currentFilePath = Path.Combine(Application.StartupPath, "games.json");
            string url = "https://raw.githubusercontent.com/Artariya/Hamster-Key-Generator/master/Hamster%20Key%20Generator/games.json";
            buttonUpdate.Enabled = false;
            try
            {
                string remoteJsonContent = await url.GetStringAsync();
                if (File.Exists(currentFilePath))
                {
                    string localJsonContent = File.ReadAllText(currentFilePath);
                    if (JToken.DeepEquals(JToken.Parse(localJsonContent), JToken.Parse(remoteJsonContent)))
                    {
                        MessageBox.Show("The program is already up to date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                File.WriteAllText(currentFilePath, remoteJsonContent);
                MessageBox.Show("The program has been updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonUpdate.Enabled = true;
        }

        private void notifyIconMain_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Focus();
        }
    }
}