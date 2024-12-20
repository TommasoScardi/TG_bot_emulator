using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Resources;
using System.Text;
using System.IO;
using System.Net;
using System.ComponentModel;

using Newtonsoft.Json;
using TG_bot_emulator.HelperForms;
using TG_bot_emulator.Models;
using System.Diagnostics;

namespace TG_bot_emulator
{
    public partial class FormBotEmulator : Form
    {
        BotConfigModel _selectedBotConfig;
        BindingList<BotConfigModel> _botsConfig;
        BindingList<Models.UserModel> _users;
        List<InteractionModel> _tgInteractions;
        RequestModeModel _requestMode;

        public FormBotEmulator()
        {
            _botsConfig = new BindingList<BotConfigModel>();
            _users = new BindingList<Models.UserModel>();
            _tgInteractions = new List<InteractionModel>();
            _requestMode = RequestModeModel.PlainText;
            InitializeComponent();
        }

        private async Task loadDataFile()
        {
            string workingDir = Path.GetDirectoryName(Application.ExecutablePath);
            if (!Path.Exists(workingDir + "/data"))
            {
                Directory.CreateDirectory(workingDir + "/data");
            }
            else if (!Path.Exists(workingDir + "/data/config.json"))
            {
                File.Create(workingDir + "/data/config.json").Close();
            }
            else if (!Path.Exists(workingDir + "/data/users.json"))
            {
                File.Create(workingDir + "/data/users.json").Close();
            }
            else if (!Path.Exists(workingDir + "/data/interactions.json"))
            {
                File.Create(workingDir + "/data/interactions.json").Close();
            }
            else
            {
                using (StreamReader fRead = new StreamReader(workingDir + "/data/config.json"))
                {
                    string fileData = await fRead.ReadToEndAsync();
                    if (fileData.Length <= 10)
                    {
                        _botsConfig = new BindingList<BotConfigModel>();
                    }
                    else
                    {
                        _botsConfig = new BindingList<BotConfigModel>(JsonConvert.DeserializeObject<IList<BotConfigModel>>(fileData));
                    }
                }
                using (StreamReader fRead = new StreamReader(workingDir + "/data/users.json"))
                {
                    string fileData = await fRead.ReadToEndAsync();
                    _users = new BindingList<Models.UserModel>(JsonConvert.DeserializeObject<IList<Models.UserModel>>(fileData));
                }

                using (StreamReader fRead = new StreamReader(workingDir + "/data/interactions.json"))
                {
                    string fileData = await fRead.ReadToEndAsync();
                    _tgInteractions = JsonConvert.DeserializeObject<List<InteractionModel>>(fileData);
                }
            }
        }

        private void saveDataFile()
        {
            string workingDir = Path.GetDirectoryName(Application.ExecutablePath);
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter fWrite = new StreamWriter(workingDir + "/data/config.json"))
            using (JsonWriter jsonWriter = new JsonTextWriter(fWrite))
            {
                serializer.Serialize(jsonWriter, _botsConfig);
            }

            using (StreamWriter fWrite = new StreamWriter(workingDir + "/data/users.json"))
            using (JsonWriter jsonWriter = new JsonTextWriter(fWrite))
            {
                serializer.Serialize(jsonWriter, _users.ToList());
            }

            using (StreamWriter fWrite = new StreamWriter(workingDir + "/data/interactions.json"))
            using (JsonWriter jsonWriter = new JsonTextWriter(fWrite))
            {
                serializer.Serialize(jsonWriter, _tgInteractions);
            }
        }

        public static async Task<HttpResponseMessage> sendRequest(BotConfigModel config, string resourceUrl, RequestModeModel mode = RequestModeModel.NONE, Models.UserModel user = null, string messageText = "", long messageId = 0, bool debug = false)
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            CookieContainer cookies = new CookieContainer();
            using (HttpClientHandler clientHandler = new HttpClientHandler() { CookieContainer = cookies })
            using (HttpClient client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(config.Url + resourceUrl);
                if (config.WebhookToken != null && config.WebhookToken.Length > 0)
                {
                    client.DefaultRequestHeaders.Add("X-Telegram-Bot-Api-Secret-Token", config.WebhookToken);
                }
                if (debug)
                {
                    cookies.Add(client.BaseAddress, new Cookie("XDEBUG_SESSION", "TG_bot_emulator"));
                }

                #region http request body
                HttpContent? body = null;
                switch (mode)
                {
                    case RequestModeModel.PlainText:
                        body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": {0},
                        ""text"": ""{1}"",
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""{3}"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {2},
                            ""first_name"": ""{3}"",
                            ""type"": ""private""
                        }},
                        ""date"": {4}
                    }}
                }}", messageId, messageText, user.Id, user.Name, timestamp), Encoding.UTF8, "application/json");
                        break;
                    case RequestModeModel.Cmd:
                        body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": {0},
                        ""text"": ""{1}"",
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""{3}"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {2},
                            ""first_name"": ""{3}"",
                            ""type"": ""private""
                        }},
                        ""date"": {4},
                        ""entities"": [
                            {{
                                ""offset"": 0,
                                ""length"": {5},
                                ""type"": ""bot_command""
                            }}
                        ]
                    }}
                }}", messageId, messageText, user.Id, user.Name, timestamp, messageText.Length), Encoding.UTF8, "application/json");
                        break;
                    case RequestModeModel.URL:
                        body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": {0},
                        ""text"": ""{1}"",
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": {3},
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {2},
                            ""first_name"": {3},
                            ""type"": ""private""
                        }},
                        ""date"": {4},
                        ""entities"": [
                            {{
                                ""offset"": 0,
                                ""length"": {5},
                                ""type"": ""url""
                            }}
                        ]
                    }}
                }}", messageId, messageText, user.Id, user.Name, timestamp, messageText.Length), Encoding.UTF8, "application/json");
                        break;
                    case RequestModeModel.Query:
                        body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""callback_query"": {{
                        ""id"": 0,
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""{3}"",
                            ""language_code"": ""it""
                        }},
                        ""data"": ""{1}"",
                        ""message"": {{
                            ""message_id"": {0},
                            ""from"": {{
                                ""id"": 0,
                                ""is_bot"": true,
                                ""first_name"": ""BOT"",
                                ""username"": ""BOT""
                            }},
                            ""chat"": {{
                                ""id"": {2},
                                ""first_name"": ""{3}"",
                                ""type"": ""private""
                            }},
                            ""date"": {4},
                            ""text"": ""Welcome to the new sharingmusicatparties bot"",
                            ""reply_markup"": {{
                                ""inline_keyboard"": [
                                    [
                                        {{
                                            ""text"": ""start a party room"",
                                            ""callback_data"": ""createNewPartyRoom""
                                        }},
                                        {{
                                            ""text"": ""join a party room"",
                                            ""callback_data"": ""joinPartyRoom""
                                        }}
                                    ]
                                ]
                            }}
                        }}
                    }}
                }}", messageId, messageText, user.Id, user.Name, timestamp), Encoding.UTF8, "application/json");
                        break;
                }
                #endregion

                HttpResponseMessage response;
                if (body != null)
                {
                    response = (await client.PostAsync(config.Url + resourceUrl, body));
                }
                else
                {
                    response = (await client.GetAsync(config.Url + resourceUrl));
                }
                return response;
            }
        }

        private async void TG_APP_Load(object sender, EventArgs e)
        {
            await loadDataFile();

            FormBotData formBotData = new FormBotData(ref _botsConfig, ref _selectedBotConfig);
            formBotData.ShowDialog();
            _selectedBotConfig = formBotData.SelectedConfig;

            if (_selectedBotConfig == null)
            {
                MessageBox.Show("nessuna configurazione caricata, chiusura programma");
                this.Close();
            }

            lbl_selectedConfig.Text = "config selected: " + _selectedBotConfig.ConfigName;

            foreach (InteractionModel interaction in _tgInteractions)
            {
                switch (interaction.RequestMode)
                {
                    case RequestModeModel.PlainText:
                        lbox_MessageText.Items.Add(interaction);
                        break;
                    case RequestModeModel.URL:
                        lbox_MessageUrl.Items.Add(interaction);
                        break;
                    case RequestModeModel.Cmd:
                        lbox_MessageCmd.Items.Add(interaction);
                        break;
                    case RequestModeModel.Query:
                        lbox_MessageQuery.Items.Add(interaction);
                        break;
                }
            }

            cbo_Users.DataSource = _users;
        }

        private void TG_APP_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveDataFile();
        }

        private void showConfigBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBotData formBotData = new FormBotData(ref _botsConfig, ref _selectedBotConfig);
            formBotData.ShowDialog();
            _selectedBotConfig = formBotData.SelectedConfig;

            if (_selectedBotConfig == null)
            {
                MessageBox.Show("nessuna configurazione caricata, chiusura programma");
                this.Close();
            }

            lbl_selectedConfig.Text = "config selected: " + _selectedBotConfig.ConfigName;
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new FormAddUser(ref _users);
            formAddUser.ShowDialog();
        }

        private void authToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWebhookSecretAuth formWebhookSecretAuth = new FormWebhookSecretAuth(this, ref _selectedBotConfig);
            formWebhookSecretAuth.ShowDialog();
        }

        #region radiobutton events
        private void rbtn_ModeText_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestModeModel.PlainText;
        }

        private void rbtn_ModeUrl_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestModeModel.URL;
        }

        private void rbtn_ModeCmd_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestModeModel.Cmd;
        }

        private void rbtn_ModeQuery_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestModeModel.Query;
        }
        #endregion

        private void txt_Message_TextChanged(object sender, EventArgs e)
        {
            if (txt_MessageText.Text.Length > 0 && txt_MessageText.Text[0] == '/')
            {
                rbtn_MessageTypeCMD.Select();
                txt_MessageText.Select();
            }
            else if (txt_MessageText.Text.Length > 4 && txt_MessageText.Text.Substring(0, 4) == "http")
            {
                rbtn_MessageTypeURL.Select();
                txt_MessageText.Select();
            }
            else if (txt_MessageText.Text.Length <= 0)
            {
                rbtn_MessageTypeText.Select();
                txt_MessageText.Select();
                ch_SaveMessage.Checked = true;
            }
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            if (txt_MessageText.Text.Length <= 0)
            {
                MessageBox.Show("Message field empty");
                return;
            }

            if (this._users.Count == 0)
            {
                MessageBox.Show("Nessun utente salvato utilizzabile per effettuare la richiesta");
                return;
            }

            if (this.cbo_Users.SelectedIndex < 0)
            {
                MessageBox.Show("Nessun utente selezionato dal combo box, prima di effettuare la richiesta seleziona l'utente con cui la vuoi selezionare");
                return;
            }

            lbl_responseStatus.Text = string.Format("response status: {0} ({1})", "ONGOING", "xxx");
            lbl_responseTime.Text = "time:";
            int messageId = 0;

            Stopwatch reqTimeElapsed = Stopwatch.StartNew();
            try
            {
                HttpResponseMessage res = await sendRequest(_selectedBotConfig
                    , _selectedBotConfig.UrlWebhookEndpoint
                    , _requestMode
                    , cbo_Users.SelectedItem as Models.UserModel
                    , txt_MessageText.Text
                    , txt_MessageId.Text.Length > 0 && int.TryParse(txt_MessageId.Text, out messageId) ? messageId : 0
                    , toggleXDebugToolStripMenuItem.Checked);
                HttpStatusCode stsCode = res.StatusCode;
                HttpContentHeaders resHeaders = res.Content.Headers;

                string httpResBody = (await res.Content.ReadAsStringAsync());
                reqTimeElapsed.Stop();

                if (resHeaders.ContentType.MediaType == "application/json")
                {
                    rtxt_ResponseBody.Text = Newtonsoft.Json.Linq.JToken.Parse(httpResBody).ToString(Formatting.Indented);
                }
                else
                {
                    rtxt_ResponseBody.Text = httpResBody;
                }

                res.Dispose();

                lbl_responseStatus.Text = string.Format("response status: {0} ({1})", "ENDED", (int)stsCode);
                lbl_responseTime.Text = string.Format("time: {0} s", reqTimeElapsed.Elapsed.TotalSeconds);

                if (stsCode == HttpStatusCode.OK && ch_SaveMessage.Checked)
                {
                    ch_SaveMessage.Checked = false;
                    InteractionModel newInteraction = new InteractionModel(txt_MessageText.Text, _requestMode);
                    _tgInteractions.Add(newInteraction);
                    switch (newInteraction.RequestMode)
                    {
                        case RequestModeModel.PlainText:
                            lbox_MessageText.Items.Add(newInteraction);
                            break;
                        case RequestModeModel.URL:
                            lbox_MessageUrl.Items.Add(newInteraction);
                            break;
                        case RequestModeModel.Cmd:
                            lbox_MessageCmd.Items.Add(newInteraction);
                            break;
                        case RequestModeModel.Query:
                            lbox_MessageQuery.Items.Add(newInteraction);
                            break;
                    }
                }
            }
            catch (WebException webEx)
            {
                MessageBox.Show("Web Exception:\n" + webEx.Message);
            }
            catch (TaskCanceledException)
            {
                lbl_responseStatus.Text = string.Format("response status: {0} ({1})", "TIMEOUT", "?");
            }
            catch (HttpRequestException httpExc)
            {

                MessageBox.Show(httpExc.Message, "HTTP request error");
            }
            finally
            {
                if (reqTimeElapsed.IsRunning)
                {
                    reqTimeElapsed.Stop();
                }
            }
        }

        private void txt_MessageText_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_MessageText.Text.Length > 0 && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F5))
            {
                btn_Send_Click(null, null);
            }
        }

        #region list box selected item changed events
        private void lbox_MessageText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageText.Text;
            rbtn_MessageTypeText.Select();

            lbox_MessageUrl.SelectedIndex = -1;
            lbox_MessageCmd.SelectedIndex = -1;
            lbox_MessageQuery.SelectedIndex = -1;
        }

        private void lbox_MessageUrl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageUrl.Text;
            rbtn_MessageTypeURL.Select();

            lbox_MessageText.SelectedIndex = -1;
            lbox_MessageCmd.SelectedIndex = -1;
            lbox_MessageQuery.SelectedIndex = -1;
        }

        private void lbox_MessageCmd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageCmd.Text;
            rbtn_MessageTypeCMD.Select();

            lbox_MessageText.SelectedIndex = -1;
            lbox_MessageUrl.SelectedIndex = -1;
            lbox_MessageQuery.SelectedIndex = -1;
        }

        private void lbox_MessageQuery_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageQuery.Text;
            rbtn_MessageTypeQuery.Select();

            lbox_MessageText.SelectedIndex = -1;
            lbox_MessageUrl.SelectedIndex = -1;
            lbox_MessageCmd.SelectedIndex = -1;
        }
        #endregion

        private void btn_CleanMessageText_Click(object sender, EventArgs e)
        {
            txt_MessageText.Text = string.Empty;
        }

        private void btn_CleanResponseBody_Click(object sender, EventArgs e)
        {
            rtxt_ResponseBody.Text = string.Empty;
        }

        private async void btn_CronRequest_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_responseStatus.Text = string.Format("response status: {0} ({1})", "ONGOING", "xxx");
                HttpResponseMessage res = await sendRequest(_selectedBotConfig, _selectedBotConfig.UrlCronEndpoint, debug:toggleXDebugToolStripMenuItem.Checked);
                HttpStatusCode stsCode = res.StatusCode;
                rtxt_ResponseBody.Text = "CRON:\n" + (await res.Content.ReadAsStringAsync());
                res.Dispose();
                lbl_responseStatus.Text = string.Format("response status: {0} ({1})", "ENDED", (int)stsCode);
            }
            catch (WebException webEx)
            {
                MessageBox.Show("Web Exception:\n" + webEx.Message);
            }
            catch (TaskCanceledException)
            {
                lbl_responseStatus.Text = string.Format("response status: {0} ({1})", "TIMEOUT", "?");
            }
            catch (HttpRequestException httpExc)
            {

                MessageBox.Show(httpExc.Message, "HTTP request error");
            }
        }

        private void toggleXDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleXDebugToolStripMenuItem.Checked = !toggleXDebugToolStripMenuItem.Checked;
        }
    }

}