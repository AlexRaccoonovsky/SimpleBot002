using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.Model;
using SimpleBot002.View;

namespace SimpleBot002.Controller
{
    public class Listener
    {
        TxtMessageStorage msgTxtStrg = new TxtMessageStorage();
        public void FixConnectorEvent(object sndr, ConnectorArgs arg)
        {
            if (sndr is BotConnector)
            {
                switch (arg.nameEvent)
                {
                    case "Connected":
                        MessageMaker.CreateNotice(msgTxtStrg.noticeConnected);

                        break;
                    default: throw new ArgumentException("Error!");
                }
                
            }
        }
    }
}
