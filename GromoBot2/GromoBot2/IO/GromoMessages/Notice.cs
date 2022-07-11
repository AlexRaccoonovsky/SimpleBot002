using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.GromoMessages;

namespace GromoBot2.IO.GromoMessages
{
    public class Notice:GromoMessage
    {
        string msgText = "EmptyText";
        ConsoleColor fontColor = GromoMessage.noticeColor;
        public Notice(string txt)
        { 
            this.msgText = txt;
        }
        public override string textMessage
        {
            get { return msgText; }
            set { msgText = value; }
        }

    }
}
