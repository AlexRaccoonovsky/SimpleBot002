using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Messages;
using SimpleBot002.Model;
using SimpleBot002.View;
using SimpleBot002.DTO;
using StockSharp.BusinessEntities;

namespace SimpleBot002.Controller
{
    public class Dispatcher
    {
        BotConnector _sBotConnector;
        MessagePresenter _msgPresenter;
        TxtMessageStorage _txtMessageStorage;
        Listener _listener;
        int benchmarkPosition;
        int limitOrderReg;
        int countOrderBuy;
        int countOrderSell;
        
        // Registration events of Connector
        void RegisterModelEvents()
        {
            // Subscribe Listener of Controller on ConnectedEvent
            //_sBotConnector.EventConnected += Listener.FixEvent;
            _sBotConnector.EventConnected += ConnectedEventHndlr;
            _sBotConnector.SecuritySelected += SecuritySelectedEventHndlr;
            _sBotConnector.PortfolioSelected += PortfolioSelectedEventHndlr;
        }

        private void PortfolioSelectedEventHndlr(object sndr, PortfolioArgs arg)
        {
            Notice portfIsSelected;
            portfIsSelected = MessageMaker.CreateNotice(_txtMessageStorage.noticePortfolioSelected + arg.selectPortfolio.Name);
            _msgPresenter.ShowNotice(portfIsSelected);
        }

        private void SecuritySelectedEventHndlr(object sndr, SecurityArgs arg)
        {
            Notice secIsSelected;
            secIsSelected = MessageMaker.CreateNotice(_txtMessageStorage.noticeSecuritySelected+arg.selectedSecurity.Id);
            _msgPresenter.ShowNotice(secIsSelected);
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
            // Limit of attempt for Order registration
            limitOrderReg = 5;
            // Count for current registration OrderBUY
            countOrderBuy = 0;
            // Count for current registration OrderSELL
            countOrderSell = 0;


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
            // TODO:!!!ReportingMode
            else {Console.WriteLine("Why?"); }
        }
        void TestConnectionMode()
        {
            // Take information about Current State of Connection
            ConnectionStates curState = _sBotConnector.TestConnectionState();
            string strCurState = curState.ToString();
            // Prepare string for notice
            string strConState = _txtMessageStorage.noticeCurrentState + strCurState;
            // Create Notice
            Notice currentState = MessageMaker.CreateNotice(strConState);
            _msgPresenter.ShowNotice(currentState);
        }
        void PrepareTrading()
        {
            // Select Default Security
            _sBotConnector.SelectFortsSecurities();
            _sBotConnector.SelectPortfolio();
        }

        void TraderMode()
        {
            //Security selectedSecurity = _sBotConnector.selectedSecurity;
            //_sBotConnector.PushOrder(selectedSecurity);

            
        }

        public void Start()
        {
            this.ConfigEnvironment();
            this.MeetingMode();
            this.TestConnectionMode();
            this.PrepareTrading();
            this.TraderMode();

        }
        void ConnectedEventHndlr(object sndr, ConnectorArgs nameEvent)
        {
            Notice noticeConnected;
            noticeConnected = MessageMaker.CreateNotice(_txtMessageStorage.noticeConnected);
            _msgPresenter.ShowNotice(noticeConnected);
            this.TestConnectionMode();
        }
    }
}
