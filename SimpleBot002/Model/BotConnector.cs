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
        Connector botConnector;
        void ConfigConnector(Listener obj)
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
            botConnector.Connected += obj.ControllerEventHandler;
        }
        public void StartConnector(Listener obj)
        {
            Listener listener = (Listener) obj;
            ConfigConnector(listener);
            botConnector.Connect();

        }

        // !!!Helper method
        static void DisplayDelegateInfo(Action obj) 
        {
            foreach (Action d in obj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}",d.Target);
            }
        }

    }

}
