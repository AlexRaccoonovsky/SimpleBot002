using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.BusinessEntities;
using StockSharp.Algo;
using StockSharp.Algo.Storages;
using StockSharp.Quik;
using StockSharp.Quik.Lua;
using StockSharp.Messages;
using Ecng.Common;
using System.Security;
using System.Net;
using StockSharp.Fix;
using Ecng.Collections;
using System.Collections.Generic;



namespace SBot003.Model
{
    public class SBotConnector
    {
        Connector connector;
        void ToConfigConnector()
        {
            connector = new Connector();
            #region "Registration settings in an adapter"
            var luaFixMarketDataMessageAdapter = new LuaFixMarketDataMessageAdapter(connector.TransactionIdGenerator)
            {
                Address = "localhost:5001".To<EndPoint>(),
                Login = "quik",
                Password = "quik".To<SecureString>(),
            };
            var luaFixTransactionMessageAdapter = new LuaFixTransactionMessageAdapter(connector.TransactionIdGenerator)
            {
                Address = "localhost:5001".To<EndPoint>(),
                Login = "quik",
                Password = "quik".To<SecureString>(),
            };
            connector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
            connector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);
            #endregion
        }
        public void ToConnect()
        { 
            this.ToConfigConnector();
            connector.Connect();
        }
        public ConnectionStates ToCheckConnectionState()
        {
            return connector.ConnectionState;
        }
    }
}
