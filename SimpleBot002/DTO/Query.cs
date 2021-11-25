using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public class Query:Message
    {
        public string nameEventRelated { get; set; }
        public string messageText { get; set; }
        public bool isPresent { get; set; }
        public Answer answer { get; set; }
        public Query(string txtQuery = "EmptyQuery")
        {
            messageText = txtQuery;
            isPresent = false;
            answer = null;
        }
        public Query (string txtQuery = "EmptyQuery", bool isPresent = false)
        {
            messageText = txtQuery;
            this.isPresent = isPresent;
            answer = null;
        }
        
    }
}
