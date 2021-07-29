using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.Model;

namespace SimpleBot002.Controller
{
    internal class ModelListener
    {
        public Action delegaController { get; set; }
        public void StartToListen()
        {
            delegaController = new Action(EchoFromControl);
        }

        private void EchoFromControl()
        {
            Console.WriteLine("EchoFromControl: botconnector is CONNECTED!");
        }
    }
}
