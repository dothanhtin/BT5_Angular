using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.RestApi.Chat
{
    public class Message
    {
        public string user_sendMessage { get; set; }
        public string user_receivedMessage { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
        public string id { get; set; }
    }
}
