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

namespace TG_sender_emulator
{
    public partial class TG_APP : Form
    {
        string _token = "";
        long _userid = 0;
        RequestMode _requestMode;
        List<TG_Interaction> _tgInteractions;

        public TG_APP()
        {
            _requestMode = RequestMode.PlainText;
            _tgInteractions = new List<TG_Interaction>();
            InitializeComponent();
        }

        private void loadDataFile(ref string authToken, ref long userId, ref List<TG_Interaction> tgInteractions)
        {
            if (!Path.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data"))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data");
                File.Create(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data/data.txt").Close();
                return;
            }
            using StreamReader fRead = new StreamReader(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data/data.txt");
            if (!fRead.EndOfStream)
            {
                authToken = fRead.ReadLine().Trim();
                userId = long.Parse(fRead.ReadLine().Trim());
                tgInteractions = new List<TG_Interaction>();
                while (!fRead.EndOfStream)
                {
                    string[] data = fRead.ReadLine().Split(',');
                    tgInteractions.Add(new TG_Interaction()
                    {
                        messageText = data[0].Trim(),
                        requestMode = Enum.Parse<RequestMode>(data[1].Trim())
                    });
                }
            }
        }

        private void saveDataFile(string authToken, long userId, List<TG_Interaction> tgInteractions)
        {
            using StreamWriter fWrite = new StreamWriter(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/data/data.txt");
            fWrite.WriteLine(authToken);
            fWrite.WriteLine(userId.ToString());
            foreach (TG_Interaction interaction in tgInteractions)
            {
                fWrite.WriteLine(interaction.Serialize());
            }
        }

        private async Task<HttpResponseMessage> sendRequest(string token, string url, RequestMode mode, string messageText, long userId)
        {
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            if (token.Length > 0)
            {
                client.DefaultRequestHeaders.Add("X-Telegram-Bot-Api-Secret-Token", token);
            }
            HttpContent? body = null;
            switch (mode)
            {
                case RequestMode.PlainText:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": 0,
                        ""text"": ""{0}"",
                        ""from"": {{
                            ""id"": {1},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {1},
                            ""first_name"": ""Test"",
                            ""type"": ""private""
                        }},
                        ""date"": {2}
                    }}
                }}", messageText, userId, timestamp), Encoding.UTF8, "application/json");
                    break;
                case RequestMode.Cmd:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": 0,
                        ""text"": ""{0}"",
                        ""from"": {{
                            ""id"": {1},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {1},
                            ""first_name"": ""Test"",
                            ""type"": ""private""
                        }},
                        ""date"": {2},
                        ""entities"": [
                            {{
                                ""offset"": 0,
                                ""length"": {3},
                                ""type"": ""bot_command""
                            }}
                        ]
                    }}
                }}", messageText, userId, timestamp, messageText.Length), Encoding.UTF8, "application/json");
                    break;
                case RequestMode.URL:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""message"": {{
                        ""message_id"": 0,
                        ""text"": ""{0}"",
                        ""from"": {{
                            ""id"": {1},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""chat"": {{
                            ""id"": {1},
                            ""first_name"": ""Test"",
                            ""type"": ""private""
                        }},
                        ""date"": {2},
                        ""entities"": [
                            {{
                                ""offset"": 0,
                                ""length"": {3},
                                ""type"": ""url""
                            }}
                        ]
                    }}
                }}", messageText, userId, timestamp, messageText.Length), Encoding.UTF8, "application/json");
                    break;
                case RequestMode.Query:
                    body = new StringContent(string.Format(@"{{
                    ""update_id"": 0,
                    ""callback_query"": {{
                        ""id"": 0,
                        ""from"": {{
                            ""id"": {1},
                            ""is_bot"": false,
                            ""first_name"": ""Test"",
                            ""language_code"": ""it""
                        }},
                        ""data"": ""{0}"",
                        ""message"": {{
                            ""message_id"": 0,
                            ""from"": {{
                                ""id"": 6487995220,
                                ""is_bot"": true,
                                ""first_name"": ""Sharing Music At Parties"",
                                ""username"": ""sharingmusicatparties_bot""
                            }},
                            ""chat"": {{
                                ""id"": {1},
                                ""first_name"": ""Test"",
                                ""type"": ""private""
                            }},
                            ""date"": {2},
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
                }}", messageText, userId, timestamp), Encoding.UTF8, "application/json");
                    break;
            }

            HttpResponseMessage response;
            if (body != null)
            {
                response = (await client.PostAsync(url, body));
            }
            else
            {
                response = (await client.GetAsync(url));
            }
            return response;
        }

        private void TG_APP_Load(object sender, EventArgs e)
        {
            loadDataFile(ref _token, ref _userid, ref _tgInteractions);

            if (_token.Length > 0 && _userid > 0)
            {
                foreach (TG_Interaction interaction in _tgInteractions)
                {
                    switch (interaction.requestMode)
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

                txt_AuthToken.Text = _token;
                txt_UserId.Text = _userid.ToString();

                btn_SendMessage.Enabled = true;
            }
        }

        private void TG_APP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_token.Length > 0 && _userid > 0)
            {
                saveDataFile(_token, _userid, _tgInteractions);
            }
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

        private async void btn_Auth_Click(object sender, EventArgs e)
        {
            lbl_ReqSts.Text = "ONGOING";
            HttpResponseMessage res = await sendRequest("", "http://localhost/bot/src/first_config_webhook.php?SET_WEBHOOK", RequestMode.AUTH, "", 0);
            gbox_Response.Text = string.Format("({0})", (int)res.StatusCode);
            _token = (await res.Content.ReadAsStringAsync()).Trim();
            res.Dispose();
            rtxt_ResponseBody.Text = _token;
            txt_AuthToken.Text = _token;
            txt_AuthToken.ReadOnly = true;
            btn_SendMessage.Enabled = true;
            lbl_ReqSts.Text = "ENDED";
        }
        private void txt_UserId_TextChanged(object sender, EventArgs e)
        {
            if (txt_UserId.Text.Length > 0 && long.TryParse(txt_UserId.Text, out _userid))
            {
                btn_SendMessage.Enabled = true;
            }
            else
            {
                _userid = 0;
                btn_SendMessage.Enabled = false;
            }
        }

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
            HttpResponseMessage res = await sendRequest(_token, "http://localhost/bot/src/bot.php", _requestMode, txt_MessageText.Text, _userid);
            HttpStatusCode stsCode = res.StatusCode;
            gbox_Response.Text = string.Format("({0})", (int)stsCode);
            rtxt_ResponseBody.Text = (await res.Content.ReadAsStringAsync());
            res.Dispose();
            lbl_ReqSts.Text = "ENDED";
            if (stsCode == HttpStatusCode.OK)
            {
                TG_Interaction newInteraction = TG_Interaction.DeSerialize(txt_MessageText.Text, _requestMode);
                _tgInteractions.Add(newInteraction);
                switch (newInteraction.requestMode)
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

        private void lbox_MessageText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_MessageText.Text = lbox_MessageText.Text;
            rbtn_MessageTypeText.Select();
        }

        private void lbox_MessageUrl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_MessageText.Text = lbox_MessageUrl.Text;
            rbtn_MessageTypeURL.Select();
        }

        private void lbox_MessageCmd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_MessageText.Text = lbox_MessageCmd.Text;
            rbtn_MessageTypeCMD.Select();
        }

        private void lbox_MessageQuery_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_MessageText.Text = lbox_MessageQuery.Text;
            rbtn_MessageTypeQuery.Select();
        }
    }

}