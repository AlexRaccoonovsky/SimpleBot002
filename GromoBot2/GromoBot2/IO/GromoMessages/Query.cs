using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.GromoMessages
{
    public class Query:GromoMessage
    {
        string queryText = "EmptyQuery?";
        ConsoleColor fontColor = GromoMessage.queryColor;
        public Query (string txt)
        {
            this.queryText = txt;
        }
        public override string textMessage 
        { 
            get { return queryText; }
            set { queryText = value; }
        }
    }
}
