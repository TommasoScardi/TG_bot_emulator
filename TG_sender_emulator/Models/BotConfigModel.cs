using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_sender_emulator.Models
{
    public class BotConfigModel
    {
        public string ConfigName { get; set; }
        public string Url { get; set; }
        public string UrlWebhookEndpoint { get; set; }
        public string UrlWebhookSet { get; set; }
        public string UrlCronEndpoint { get; set; }
        public string WebhookToken { get; set; }
    }
}
