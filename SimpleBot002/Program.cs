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


namespace SimpleBot002
{
    class Program
    {
        static void Main(string[] args)
        {
         // Query alrt = new Query();
         // Console.WriteLine(alrt.IsPresent);
         // Console.WriteLine(alrt.messageText);
         // Console.ReadKey();
          BotConnector sBotConnector = new BotConnector();
         //
          sBotConnector.StartConnector();
         // Console.ReadLine();





        }
    }
}
