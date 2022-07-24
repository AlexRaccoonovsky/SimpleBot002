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
        string noticeText = "EmptyNotice";
        ConsoleColor fontColor = GromoMessage.noticeColor;
        public Notice(string txt)
        { 
            this.noticeText = txt;
        }
        public override string textMessage
        {
            get { return noticeText; }
            set { noticeText = value; }
        }

    }
}
