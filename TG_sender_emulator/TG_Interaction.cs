using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_sender_emulator
{
    internal class TG_Interaction
    {
        public string messageText { get; set; }
        public RequestMode requestMode { get; set; }
        public override string ToString()
        {
            return messageText;
        }

        public string Serialize()
        {
            return messageText + "," + ((int)requestMode).ToString();
        }

        public static TG_Interaction DeSerialize(string messageText, RequestMode requestMode)
        {
            return new TG_Interaction() { messageText = messageText, requestMode = requestMode };
        }

        public static TG_Interaction DeSerialize(string messageText, int requestMode)
        {
            return new TG_Interaction() { messageText = messageText, requestMode = Enum.Parse<RequestMode>(requestMode.ToString()) };
        }
    }
}
