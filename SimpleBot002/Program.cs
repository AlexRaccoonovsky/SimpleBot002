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
using SimpleBot002.Model;
using SimpleBot002.DTO;
using SimpleBot002.Controller;
using SimpleBot002.View;



namespace SimpleBot002
{
    class Program
    {
        static void Main(string[] args)
        {
            BotConnector sBotConnector = new BotConnector();
            sBotConnector.StartConnector();
            //Listener listener = new Listener();
            sBotConnector.EventConnected += Listener.FixEvent;




            //  Listener listener = new Listener();
            //  listener.StartToListen();
            //  BotConnector sBotConnector = new BotConnector();
            //  sBotConnector.StartConnector(listener);
            Console.ReadLine();





        }
    }
}
