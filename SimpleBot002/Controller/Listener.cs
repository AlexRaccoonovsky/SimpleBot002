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
        MessageTextStorage msgTxtStrg = new MessageTextStorage();
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

       //public void ConfigListener(object obj)
       //{ 
       //}
       //
       //
       //public void StartToListen()
       //{
       //    
       //}
       //private void EchoFromControl()
       //{
       //    Console.WriteLine("EchoFromControl: botconnector is CONNECTED!");
       //}

    }
}
