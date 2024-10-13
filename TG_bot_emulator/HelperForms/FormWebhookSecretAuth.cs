using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TG_bot_emulator.Models;

namespace TG_bot_emulator.HelperForms
{
    public partial class FormWebhookSecretAuth : Form
    {
        Form _caller;
        BotConfigModel _botConfig;
        public FormWebhookSecretAuth(Form caller, ref BotConfigModel botConfig)
        {
            _caller = caller;
            _botConfig = botConfig;
            InitializeComponent();
        }

        private void FormWebhookSecretAuth_Load(object sender, EventArgs e)
        {
            txt_WebhookToken.Text = _botConfig.WebhookToken;
        }

        private void btnAuthTokenSubmit_Click(object sender, EventArgs e)
        {
            _botConfig.WebhookToken = txt_WebhookToken.Text;
            MessageBox.Show("webhook set");
            this.Close();
        }

        private async void btnRequestToken_Click(object sender, EventArgs e)
        {
            string bodyRes;
            lbl_ReqSts.Text = "ONGOING";
            lbl_ResStatusCode.Text = "(xxx)";
            try
            {
                HttpResponseMessage res = await FormBotEmulator.sendRequest(_botConfig, _botConfig.UrlWebhookSet, debug: ((FormBotEmulator)_caller).toggleXDebugToolStripMenuItem.Checked);
                bodyRes = (await res.Content.ReadAsStringAsync()).Trim();
                HttpStatusCode stsCode = res.StatusCode;
                lbl_ResStatusCode.Text = string.Format("({0})", (int)stsCode);
                res.Dispose();
                lbl_ReqSts.Text = "ENDED";
                if (stsCode == HttpStatusCode.OK)
                {
                    _botConfig.WebhookToken = bodyRes;
                    ((FormBotEmulator)_caller).rtxt_ResponseBody.Text = bodyRes;
                    txt_WebhookToken.Text = bodyRes;
                    MessageBox.Show("webhook set");
                }
                else
                {
                    ((FormBotEmulator)_caller).rtxt_ResponseBody.Text = bodyRes;
                    MessageBox.Show("errore richiedendo il token del webhook attivo, per più informazioni tornare alla pagina principale, il body della risposta è salvato sull'area dedicata");
                }
            }
            catch (WebException webEx)
            {
                MessageBox.Show("Web Exception:\n" + webEx.Message);
            }
            catch (TaskCanceledException)
            {
                lbl_ReqSts.Text = "TIMEOUT";
            }
            catch (HttpRequestException httpExc)
            {

                MessageBox.Show(httpExc.Message, "HTTP request error");
            }
        }
    }
}
