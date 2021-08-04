using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public class Query:Message
    {
        public string messageText { get; set; }
        public bool IsPresent { get; set; }
        public Answer answer { get; set; }
        public Query(string txtQuery = "EmptyQuery")
        {
            messageText = txtQuery;
            IsPresent = false;
            answer = null;
        }
        public Query (string txtQuery = "EmptyQuery", bool isPresent = false)
        {
            messageText = txtQuery;
            IsPresent = isPresent;
            answer = null;
        }
        
    }
}
