using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCConcepts_Learning.Models
{
    public class Notifications
    {
        public int MessageId { get; set; } = 0;
        public string SenderName { get; set; }
        public string  ReceiverName { get; set; }
        public string  MessageTitle { get; set; }
        public int MessageBody { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public string MessageDateSt => this.MessageDate.ToString("dd-MMM-yyyyy");
    }
}
