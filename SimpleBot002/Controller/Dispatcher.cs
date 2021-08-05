using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.Model;
using SimpleBot002.View;
using SimpleBot002.DTO;

namespace SimpleBot002.Controller
{
    public class Dispatcher
    {
        BotConnector _sBotConnector;
        MessagePresenter _msgPresenter;
        TxtMessageStorage _txtMessageStorage;
        Listener _listener;
                
        // Registration events of Connector
        void RegisterModelEvents()
        {
            // Subscribe Listener of Controller on ConnectedEvent
            //_sBotConnector.EventConnected += Listener.FixEvent;
        }
        internal void ConfigEnvironment()
        {
            // Initialize MODEL
            _sBotConnector = new BotConnector();
            // Initialize VIEW
            _msgPresenter = new MessagePresenter();
            // Initialize Storage of messages text
            _txtMessageStorage = new TxtMessageStorage();
            // Initialize listener of dispatcher
            _listener = new Listener();
            // Register Events of Connector
            this.RegisterModelEvents();
         
        }
        void MeetingMode()
        {
            // Create Welcome message & transfer to Presenter of messages
            Notice WelcomeNotice = MessageMaker.CreateNotice(_txtMessageStorage.noticeWelcome);
            // VIEW invoking
            _msgPresenter.ShowNotice(WelcomeNotice);
            // Creating question about connecting
            Query _queryConnect = MessageMaker.CreateQuery(_txtMessageStorage.queryConnect);
            // Show question about connect
            Answer ans=_msgPresenter.ShowQuery(_queryConnect);
            if (ans.answerParam == "y")
            {
                _sBotConnector.StartConnector();
            }
            // !!!FarewellMode
            else {Console.WriteLine("Why?"); }
        }
        public void Start()
        {
            this.ConfigEnvironment();
            this.MeetingMode();
            _sBotConnector.EventConnected += _listener.FixConnectorEvent;


        }
    }
}
