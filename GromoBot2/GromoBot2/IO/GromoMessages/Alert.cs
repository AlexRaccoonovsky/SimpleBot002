using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.GromoMessages
{
    public class Alert : GromoMessage
    {
        string alertText = "EmptyAlert!!!!";
        ConsoleColor fontColor = GromoMessage.alertColor;
        public Alert(string txt)
        {
            this.alertText = txt;
        }
        public override string textMessage
        {
            get { return alertText; }
            set { alertText = value; }
        }
    }
}
