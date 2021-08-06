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
        public event ConnectorEvent EventConnected;
        public event ConnectorEvent SecuritySelected;

        Connector botConnector;
        public ConnectionStates connectionState { get; private set; }
        public Security selectedSecurity { get; private set; }
        public string strSecIDDefault { get; private set; } = "SIU1@FORTS";
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
            #region "Security configuration"
            // Security configuration
            string strSecIDDefault = "SIU1@FORTS";
            // Create pattern for pull only FUTURE
                Security secFutures = new Security()
                {
                    Type = SecurityTypes.Future,
                };

            botConnector.LookupSecurities(secFutures);
            #endregion
            #region"Registration Events of botConnector"
            botConnector.Connected += DefineEventConnected;
            botConnector.LookupSecuritiesResult += BotConnector_LookupSecuritiesResult;
            botConnector.PortfolioReceived += BotConnector_PortfoliosReceived;
            #endregion
        }

        private void BotConnector_PortfoliosReceived(Subscription arg1, Portfolio arg2)
        {
            selectedPortfolio = arg2;
          
                Console.WriteLine("PortfName:{0}", selectedPortfolio.Name);
                Console.WriteLine("PortfBoard:{0}", selectedPortfolio.Board);
                Console.WriteLine("PortfBeginValue:{0}", selectedPortfolio.BeginValue);
                
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
       public void GetSecurity()
       {
            // Security configuration
            string strSecIDDefault = "SIU1@FORTS";
            // Create pattern for pull only FUTURE
            Security secFutures = new Security()
            {
                Type = SecurityTypes.Future,
            };

            botConnector.LookupSecurities(secFutures);

        }

        private void BotConnector_LookupSecuritiesResult(SecurityLookupMessage arg1, System.Collections.Generic.IEnumerable<Security> arg2, Exception arg3)
        {
            Security sec;
            string strSecIDDefault = "SIU1@FORTS";
            SecurityId secIDDefault;
            IEnumerable<Security> listOfSec;
            listOfSec = botConnector.Securities;
            Security chosenSecurity;
            foreach (Security s in listOfSec)
            {
                if (s.Id.Contains(strSecIDDefault))
                    selectedSecurity = s;
            }
            if (SecuritySelected != null)
                SecuritySelected(this, new ConnectorArgs("SecurityIsSelected", selectedSecurity));
         
        }

        void  DefineEventConnected()
        {
            if (EventConnected != null)
                EventConnected(this, new ConnectorArgs("Connected"));
        }
    }
}
