using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.Model;

namespace SimpleBot002.Controller
{
    public class Listener
    {
        TxtMessageStorage msgTxtStrg = new TxtMessageStorage();
        public static void FixEvent(object sndr, ConnectorArgs arg)
        {
            if (sndr is BotConnector)
            {
                switch (arg.nameEvent)
                {
                    case "Connected": Console.WriteLine("Connnn"); break;
                    default: throw new ArgumentException("Error!");
                }
                
            }
        }
    }
}
