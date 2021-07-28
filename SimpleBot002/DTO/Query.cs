using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    class Query:Message
    {
        public Query (string msgText = "EmptyQuery", bool isPresent = false)
        {
            messageText = msgText;
            IsPresent = isPresent;
        }
        public string messageText { get; set; }
        public bool IsPresent { get; set; }
        public string Answer { get; set; }
    }
}
