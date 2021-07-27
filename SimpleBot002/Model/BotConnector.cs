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


namespace SimpleBot002.Model
{
    public class BotConnector

    {
        Connector botConnector;
        public delegate void BotHandler(string msg);
        public event BotHandler BotConnected;
        
        
        void CreateConnector()
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


            botConnector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
            botConnector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);
        }
        


        public void StartConnector()
        {
            CreateConnector();

            if (BotConnected != null)
                BotConnected("Hi-he-hu");
            else
                Console.WriteLine("List of EventConnected is empty");
            
            
            //botConnector += new BotHandler(MessageShow);
            //sBotConnector.BotConnected += new BotConnector.BotHandler(MessageShow);
            //this.BotConnected += new BotHandler(MessageShow);
            // EventInit();
            //this.BotConnected("Ha-ha-ha");
            //botConnector.Connected += () => Console.WriteLine("botconnector is CONNECTED!");
            botConnector.Connect();
            
        }

        void MessageShow(string message)
        {
            Console.WriteLine(message);
        }


        public void EventInit()
        {
             //botConnector.ConnectionError += ConnectExc => Console.WriteLine("Error:" + ConnectExc.ToString());
             // 
             //botConnector.Connected += () => Console.WriteLine("botconnector is CONNECTED!");
            //  botconnector.Disconnected += () => Console.WriteLine("botconnector is DISCONNECTED!");
            //  botconnector.TimeOut += () => Console.WriteLine("Connection time is out...");
        }





    }

}
