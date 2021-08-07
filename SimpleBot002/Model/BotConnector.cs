using System;
using Ecng.Common;
using Ecng.ComponentModel;
using StockSharp.Localization;
using StockSharp.Logging;
using StockSharp.BusinessEntities;
using StockSharp.Algo;
using StockSharp.Messages;
using StockSharp.Quik;
using StockSharp.Quik.Lua;
using MoreLinq;
using System.Security;
using System.Net;
using StockSharp.Fix;
using Ecng.Serialization;
using SimpleBot002.Controller;
using System.Collections;
using System.Collections.Generic;

namespace SimpleBot002.Model
{
    public class BotConnector
    {
        public delegate void ConnectorEvent(object sndr, ConnectorArgs nameEvent);
        public delegate void SecuritySelectedEvents(object sndr, SecurityArgs arg);
        public delegate void PorfolioSelectedEvent(object sndr, PortfolioArgs arg);
        
        public event ConnectorEvent EventConnected;
        public event SecuritySelectedEvents SecuritySelected;
        public event PorfolioSelectedEvent PortfolioSelected;

        Connector botConnector;
        public ConnectionStates connectionState { get; private set; }
        public Security selectedSecurity { get; private set; }
        public string strSecIDDefault { get; private set; } = "SIU1@FORTS";
        public string strPortfDefault { get; private set; } = "7600oba";
        public Portfolio selectedPortfolio { get; private set; }


        void ConfigConnector()
        {
            botConnector = new Connector();
            var luaFixMarketDataMessageAdapter = new LuaFixMarketDataMessageAdapter(botConnector.TransactionIdGenerator)
            {
                Address = "localhost:5001".To<EndPoint>(),
                Login = "quik",
                Password = "quik".To<SecureString>(),
            };
            var luaFixTransactionMessageAdapter = new LuaFixTransactionMessageAdapter(botConnector.TransactionIdGenerator)
            {
                Address = "localhost:5001".To<EndPoint>(),
                Login = "quik",
                Password = "quik".To<SecureString>(),
            };
            // botConnector configuration
            // Add settings to adapters
            botConnector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
            botConnector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);
           
            
            #region"Registration Events of botConnector"
            botConnector.Connected += DefineEventConnected;
            botConnector.LookupSecuritiesResult += BotConnector_LookupSecuritiesResult;
            botConnector.LookupPortfoliosResult += BotConnector_LookupPortfoliosResult;
            botConnector.PortfolioReceived += BotConnector_PortfoliosReceived;
            botConnector.OrderRegisterFailed += BotConnector_OrderRegisterFailed;
            #endregion
        }

        private void BotConnector_LookupPortfoliosResult(PortfolioLookupMessage arg1, IEnumerable<Portfolio> arg2, Exception arg3)
        {
            foreach (Portfolio p in arg2)
            {
                if (p.Name.Contains(strPortfDefault))
                    selectedPortfolio = p;
            }

            if (PortfolioSelected != null)
                PortfolioSelected(this, new PortfolioArgs("PortfolioSelected", selectedPortfolio));


        }

        private void BotConnector_OrderRegisterFailed(OrderFail obj)
        {
            Console.WriteLine("OrderFailed");
        }

        private void BotConnector_PortfoliosReceived(Subscription arg1, Portfolio arg2)
        {
        //selectedPortfolio = arg2;
        //
        //  Console.WriteLine("PortfName:{0}", selectedPortfolio.Name);
        //  Console.WriteLine("PortfBoard:{0}", selectedPortfolio.Board);
        //  Console.WriteLine("PortfBeginValue:{0}", selectedPortfolio.BeginValue);
            
                
        }

        public void SetPortfolio()
        {
            string strNameportfolio = "7600oba";
            Portfolio _portf = new Portfolio()
            {
                
                Name = strNameportfolio,
            };
            botConnector.LookupPortfolios(_portf);

        }
        

        public void StartConnector()
        {
            ConfigConnector();
            botConnector.Connect();
        }
        public ConnectionStates TestConnectionState()
        {
            return botConnector.ConnectionState;
        }
       public void SelectFortsSecurities()
       {
            // Create pattern for pull only FUTURES
            Security secFutures = new Security()
            {
                Type = SecurityTypes.Future,
            };

            botConnector.LookupSecurities(secFutures);

        }

        private void BotConnector_LookupSecuritiesResult(SecurityLookupMessage arg1, System.Collections.Generic.IEnumerable<Security> arg2, Exception arg3)
        {
            IEnumerable<Security> listOfSec;
            listOfSec = botConnector.Securities;
            foreach (Security s in listOfSec)
                    {
                        if (s.Id.Contains(strSecIDDefault))
                            selectedSecurity = s;
                    }
            if (SecuritySelected != null)
                SecuritySelected(this, new SecurityArgs("SecurityIsSelected", selectedSecurity));
         
        }
        public void PushOrder(Security sec)
        {
           //botConnector.RegisterSecurity(sec);
           //botConnector.RegisterPortfolio(selectedPortfolio);
           //botConnector.RegisterMarketDepth(sec);
           //Order _fOrder = new Order
           //{
           //    Security = sec,
           //    Portfolio = selectedPortfolio,
           //    Volume = 1,
           //    Direction = Sides.Buy,
           //    Price = 73666,
           //};
           //botConnector.RegisterOrder(_fOrder);
        }

        void  DefineEventConnected()
        {
            if (EventConnected != null)
                EventConnected(this, new ConnectorArgs("Connected"));
        }
    }
}
