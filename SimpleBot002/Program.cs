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

namespace SimpleBot001
{
    class Program
    {
        static void Main(string[] args)
        {
            Connector botconnector;
            botconnector = new Connector();

           var luaFixMarketDataMessageAdapter = new LuaFixMarketDataMessageAdapter(botconnector.TransactionIdGenerator)
           {
               Address = "localhost:5001".To<EndPoint>(),
               Login = "quik",
               Password = "quik".To<SecureString>(),
           };
           
           var luaFixTransactionMessageAdapter = new LuaFixTransactionMessageAdapter(botconnector.TransactionIdGenerator)
           {
               Address = "localhost:5001".To<EndPoint>(),
               Login = "quik",
               Password = "quik".To<SecureString>(),
           };
           
           
             botconnector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
             botconnector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);

            botconnector.Connected += () => Console.WriteLine("botconnector is CONNECTED!");
            botconnector.ConnectionError += ConnectExc => Console.WriteLine("Error:" + ConnectExc.ToString());
            botconnector.Disconnected += () => Console.WriteLine("botconnector is DISCONNECTED!");
            botconnector.TimeOut += () => Console.WriteLine("Connection time is out...");




            botconnector.Connect();
            Console.Read();



        }
    }
}
