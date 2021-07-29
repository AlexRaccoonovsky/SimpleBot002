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
        
        //public delegate void MyDelega();
        Action delega;
        
        
        
        
        //public event BotHandler BotConnected;


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


            botConnector.Adapter.InnerAdapters.Add(luaFixMarketDataMessageAdapter);
            botConnector.Adapter.InnerAdapters.Add(luaFixTransactionMessageAdapter);
        }
        
        public void StartConnector()
        {
            ModelListener modelListener = new ModelListener();
            modelListener.StartToListen();
            
            ConfigConnector();
            delega = new Action(ExecMeth);
            delega += new Action(modelListener.delegaController);
            DisplayDelegateInfo(delega);
            botConnector.Connected +=delega;
            //botConnector.Connected += modelListener.delegaController;
             
            botConnector.Connect();

        }
        static void DisplayDelegateInfo(Action obj) 
        {
            foreach (Action d in obj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}",d.Target);
            }
        }
        static void ExecMeth() 
        {
            Console.WriteLine("botconnector is CONNECTED!");
        }
    }

}
