using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Resources;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using Microsoft.VisualBasic;

using Newtonsoft.Json;
using TG_sender_emulator.Models;
using System.ComponentModel;

namespace TG_sender_emulator
{
    public partial class FormEmulatorMessageSender : Form
    {
        BotConfig _selectedBotConfig;
        BindingList<BotConfig> _botsConfig;
        BindingList<Models.User> _users;
        List<TG_Interaction> _tgInteractions;
        RequestMode _requestMode;

        public FormEmulatorMessageSender()
        {
            _botsConfig = new BindingList<BotConfig>();
            _users = new BindingList<Models.User>();
            _tgInteractions = new List<TG_Interaction>();
            _requestMode = RequestMode.PlainText;
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
                        _botsConfig = new BindingList<BotConfig>();
                    }
                    else
                    {
                        _botsConfig = new BindingList<BotConfig>(JsonConvert.DeserializeObject<IList<BotConfig>>(fileData));
                    }
                }
                using (StreamReader fRead = new StreamReader(workingDir + "/data/users.json"))
                {
                    string fileData = await fRead.ReadToEndAsync();
                    _users = new BindingList<Models.User>(JsonConvert.DeserializeObject<IList<Models.User>>(fileData));
                }

                using (StreamReader fRead = new StreamReader(workingDir + "/data/interactions.json"))
                {
                    string fileData = await fRead.ReadToEndAsync();
                    _tgInteractions = JsonConvert.DeserializeObject<List<TG_Interaction>>(fileData);
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

        public static async Task<HttpResponseMessage> sendRequest(BotConfig config, string resourceUrl, RequestMode mode = RequestMode.NONE, long userId = 0, string messageText = "", long messageId = 0)
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(config.Url + resourceUrl);
            if (config.WebhookToken.Length > 0)
            {
                client.DefaultRequestHeaders.Add("X-Telegram-Bot-Api-Secret-Token", config.WebhookToken);
            }
            HttpContent? body = null;
            switch (mode)
            {
                case RequestMode.PlainText:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": {0},
                        ""text"": ""{1}"",
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {2},
                            ""first_name"": ""Test"",
                            ""type"": ""private""
                        }},
                        ""date"": {3}
                    }}
                }}", messageId, messageText, userId, timestamp), Encoding.UTF8, "application/json");
                    break;
                case RequestMode.Cmd:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": {0},
                        ""text"": ""{1}"",
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {2},
                            ""first_name"": ""Test"",
                            ""type"": ""private""
                        }},
                        ""date"": {3},
                        ""entities"": [
                            {{
                                ""offset"": 0,
                                ""length"": {4},
                                ""type"": ""bot_command""
                            }}
                        ]
                    }}
                }}", messageId, messageText, userId, timestamp, messageText.Length), Encoding.UTF8, "application/json");
                    break;
                case RequestMode.URL:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": {0},
                        ""text"": ""{1}"",
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {2},
                            ""first_name"": ""Test"",
                            ""type"": ""private""
                        }},
                        ""date"": {3},
                        ""entities"": [
                            {{
                                ""offset"": 0,
                                ""length"": {4},
                                ""type"": ""url""
                            }}
                        ]
                    }}
                }}", messageId, messageText, userId, timestamp, messageText.Length), Encoding.UTF8, "application/json");
                    break;
                case RequestMode.Query:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""callback_query"": {{
                        ""id"": 0,
                        ""from"": {{
                            ""id"": {2},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""data"": ""{1}"",
                        ""message"": {{
                            ""message_id"": {0},
                            ""from"": {{
                                ""id"": 6487995220,
                                ""is_bot"": true,
                                ""first_name"": ""Sharing Music At Parties"",
                                ""username"": ""sharingmusicatparties_bot""
                            }},
                            ""chat"": {{
                                ""id"": {2},
                                ""first_name"": ""Test"",
                                ""type"": ""private""
                            }},
                            ""date"": {3},
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
                }}", messageId, messageText, userId, timestamp), Encoding.UTF8, "application/json");
                    break;
            }

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

        private async void TG_APP_Load(object sender, EventArgs e)
        {
            await loadDataFile();

            FormBotData formBotData = new FormBotData(_botsConfig, _selectedBotConfig);
            formBotData.ShowDialog();
            _selectedBotConfig = formBotData.SelectedConfig;

            if (_selectedBotConfig == null)
            {
                MessageBox.Show("nessuna configurazione caricata, chiusura programma");
                this.Close();
            }

            foreach (TG_Interaction interaction in _tgInteractions)
            {
                switch (interaction.RequestMode)
                {
                    case RequestMode.PlainText:
                        lbox_MessageText.Items.Add(interaction);
                        break;
                    case RequestMode.URL:
                        lbox_MessageUrl.Items.Add(interaction);
                        break;
                    case RequestMode.Cmd:
                        lbox_MessageCmd.Items.Add(interaction);
                        break;
                    case RequestMode.Query:
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
            FormBotData formBotData = new FormBotData(_botsConfig, _selectedBotConfig);
            formBotData.ShowDialog();
            _selectedBotConfig = formBotData.SelectedConfig;

            if (_selectedBotConfig == null)
            {
                MessageBox.Show("nessuna configurazione caricata, chiusura programma");
                this.Close();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new FormAddUser(_users);
            formAddUser.ShowDialog();
        }

        private void authToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWebhookSecretAuth formWebhookSecretAuth = new FormWebhookSecretAuth(this, _selectedBotConfig);
            formWebhookSecretAuth.ShowDialog();
        }

        #region radiobutton events
        private void rbtn_ModeText_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestMode.PlainText;
        }

        private void rbtn_ModeUrl_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestMode.URL;
        }

        private void rbtn_ModeCmd_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestMode.Cmd;
        }

        private void rbtn_ModeQuery_CheckedChanged(object sender, EventArgs e)
        {
            _requestMode = RequestMode.Query;
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

            lbl_ReqSts.Text = "ONGOING";
            int messageId = 0;
            HttpResponseMessage res = await sendRequest(_selectedBotConfig, _selectedBotConfig.UrlWebhookEndpoint, _requestMode, ((Models.User)cbo_Users.SelectedItem).Id, txt_MessageText.Text, txt_MessageId.Text.Length > 0 && int.TryParse(txt_MessageId.Text, out messageId) ? messageId : 0);
            HttpStatusCode stsCode = res.StatusCode;
            lbl_ResStatusCode.Text = string.Format("({0})", (int)stsCode);
            rtxt_ResponseBody.Text = (await res.Content.ReadAsStringAsync());
            res.Dispose();
            lbl_ReqSts.Text = "ENDED";
            if (stsCode == HttpStatusCode.OK && ch_SaveMessage.Checked)
            {
                ch_SaveMessage.Checked = false;
                TG_Interaction newInteraction = new TG_Interaction(txt_MessageText.Text, _requestMode);
                _tgInteractions.Add(newInteraction);
                switch (newInteraction.RequestMode)
                {
                    case RequestMode.PlainText:
                        lbox_MessageText.Items.Add(newInteraction);
                        break;
                    case RequestMode.URL:
                        lbox_MessageUrl.Items.Add(newInteraction);
                        break;
                    case RequestMode.Cmd:
                        lbox_MessageCmd.Items.Add(newInteraction);
                        break;
                    case RequestMode.Query:
                        lbox_MessageQuery.Items.Add(newInteraction);
                        break;
                }
            }
        }

        private void txt_MessageText_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_MessageText.Text.Length > 0 && e.KeyCode == Keys.Enter)
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
        }

        private void lbox_MessageUrl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageUrl.Text;
            rbtn_MessageTypeURL.Select();
        }

        private void lbox_MessageCmd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageCmd.Text;
            rbtn_MessageTypeCMD.Select();
        }

        private void lbox_MessageQuery_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ch_SaveMessage.Checked = false;
            txt_MessageText.Text = lbox_MessageQuery.Text;
            rbtn_MessageTypeQuery.Select();
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
            lbl_ReqSts.Text = "ONGOING";
            HttpResponseMessage res = await sendRequest(_selectedBotConfig, _selectedBotConfig.UrlCronEndpoint);
            gbox_Response.Text = string.Format("({0})", (int)res.StatusCode);
            rtxt_ResponseBody.Text = "CRON:\n" + (await res.Content.ReadAsStringAsync());
            res.Dispose();
            lbl_ReqSts.Text = "ENDED";
        }
    }

}