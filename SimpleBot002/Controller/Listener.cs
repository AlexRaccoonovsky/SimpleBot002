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
        public Action ControllerEventHandler { get; set; }
        public void StartToListen()
        {
            ControllerEventHandler = new Action(EchoFromControl);
        }
        private void EchoFromControl()
        {
            Console.WriteLine("EchoFromControl: botconnector is CONNECTED!");
        }

    }
}
