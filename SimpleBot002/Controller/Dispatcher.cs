using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.Model;
using SimpleBot002.View;

namespace SimpleBot002.Controller
{
    public class Dispatcher
    {
        void ConfigEnvironment()
        {
            // Initialize MODEL
            BotConnector _sBotConnector = new BotConnector();
            // Initialize VIEW
            MessagePresenter _msgPresenter = new MessagePresenter();
            // Initialize Events of MODEL
            _sBotConnector.EventConnected += Listener.FixEvent;
            // Launching MODEL
            _sBotConnector.StartConnector();
            
        }
        public void Start()
        {
            this.ConfigEnvironment();

        }
    }
}
