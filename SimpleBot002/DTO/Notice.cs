using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public class Notice:Message
    {
        public Notice(string msgText = "EmptyNotice")
        {
            messageText = msgText;
            IsPresent = false;
        }
        public Notice(string msgText = "EmptyNotice", bool isPresent = false)
        {
            messageText = msgText;
            IsPresent = isPresent;
        }
        public string messageText { get; set; }
        public bool IsPresent { get; set; }

    }
}
