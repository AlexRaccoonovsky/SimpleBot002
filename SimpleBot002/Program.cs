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

namespace SimpleBot002
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BotConnector sBotConnector = new BotConnector();
            


            
             sBotConnector.BotConnected += new BotConnector.BotHandler(MessageShow);
            //sBotConnector.BotConnected += () => Console.WriteLine("botconnector is CONNECTED!");

            sBotConnector.StartConnector();
            Console.ReadLine();

            void MessageShow(string message)
            {
                Console.WriteLine(message);
            }


            //botconnector.Connect();
            //Console.Read();



        }
    }
}
