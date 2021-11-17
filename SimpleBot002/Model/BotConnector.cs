using System;
using Ecng.Common;
using Ecng.ComponentModel;
using StockSharp.Localization;
using StockSharp.Logging;
using StockSharp.BusinessEntities;
using StockSharp.Algo;
using StockSharp.Algo.Storages;
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
        public string strSecIDDefault { get; private set; } = "SIZ1@FORTS";
        public string strPortfDefault { get; private set; } = "7600oba";
        public Portfolio selectedPortfolio { get; private set; }

        public IPortfolioProvider portfolioProvider;
        
        public IPositionStorage positionStorage;

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
            botConnector.OrderRegisterFailed += BotConnector_OrderRegisterFailed;
            #endregion
        }

       

        private void BotConnector_LookupPortfoliosResult(PortfolioLookupMessage arg1, IEnumerable<Portfolio> arg2, Exception arg3)
        {
          //  foreach (Portfolio p in botConnector.Portfolios)
          //  {
          //      Console.WriteLine("DATA RECEIVED FROM botConnector.Portfolios:");
          //      Console.WriteLine("Name: {0}", p.Name);
          //      Console.WriteLine("Board: {0}", p.Board.ToString());
          //  }
              foreach (Portfolio p in botConnector.RegisteredPortfolios)
              {
                  Console.WriteLine("DATA RECEIVED FROM botConnector.RegisteredPortfolios:");
                  Console.WriteLine("Name: {0}", p.Name);
                  Console.WriteLine("Board: {0}", p.Board.ToString());
              }
            //___________________________
            //  positionStorage = new IPositionStorage();
            //portfolioProvider = new IPortfolioProvider();
            //selectedPortfolio=TraderHelper.Sa
            //botConnector
            if (PortfolioSelected != null)
                PortfolioSelected(this, new PortfolioArgs("PortfolioSelected", selectedPortfolio));
        }

        private void BotConnector_OrderRegisterFailed(OrderFail obj)
        {
            Console.WriteLine("OrderFailed");
        }


        public void SelectPortfolio()
        {
            string strNameportfolio = "7600oba";
            //botConnector.GetPortfolio(strNameportfolio);
            selectedPortfolio = botConnector.LookupByPortfolioName(strNameportfolio);
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
