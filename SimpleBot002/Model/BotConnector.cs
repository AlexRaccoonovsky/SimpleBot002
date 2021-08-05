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


namespace SimpleBot002.Model
{
    public class BotConnector
    {
        public delegate void ConnectorEvent(object sndr, ConnectorArgs nameEvent);
        public event ConnectorEvent EventConnected;
        Connector botConnector;
        public ConnectionStates connectionState { get; private set; }
        
        
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
            botConnector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
            botConnector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);
            // Registration Events of botConnector
            botConnector.Connected += DefineEventConnected;
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
    
        void  DefineEventConnected()
        {
            if (EventConnected != null)
                EventConnected(this, new ConnectorArgs("Connected"));
        }
    }
}
