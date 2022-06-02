using System;
using System.Collections.Generic;
using System.Text;

namespace Skillbox_Homework_10._1
{
    class MessageLog
    {
        public string time { get; set; }

        public string id { get; set; }

        public string message { get; set; }

        public string firstName { get; set; }

        public MessageLog(string time, string id, string message, string firstName)
        {
            this.time = time;
            this.id = id;
            this.message = message;
            this.firstName = firstName;
        }
    }
}
