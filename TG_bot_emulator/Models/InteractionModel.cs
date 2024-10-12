using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_sender_emulator.Models
{
    public class InteractionModel
    {
        public InteractionModel(string messageText, RequestModeModel requestMode)
        {
            MessageText = messageText;
            RequestMode = requestMode;
        }
        public string MessageText { get; set; }
        public RequestModeModel RequestMode { get; set; }
        public override string ToString()
        {
            return MessageText;
        }
    }
}
