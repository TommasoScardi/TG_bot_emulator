using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_sender_emulator.Models
{
    public class TG_Interaction
    {
        public TG_Interaction(string messageText, RequestMode requestMode)
        {
            MessageText = messageText;
            RequestMode = requestMode;
        }
        public string MessageText { get; set; }
        public RequestMode RequestMode { get; set; }
        public override string ToString()
        {
            return MessageText;
        }
    }
}
