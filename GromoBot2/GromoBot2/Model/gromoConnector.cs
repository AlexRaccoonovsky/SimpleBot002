using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Algo;
using StockSharp.Messages;
using GromoBot2.GromoExceptions.ModelExceptions;

namespace GromoBot2.Model
{
    public class GromoConnector
    {
        Connector connector { get; }
        public GromoConnector()
        {
            connector = new Connector();
        }
        public void ToConnect()
        {
            connector.Connect();
        }
        public ConnectionStates ToGetConnectionState()
        {
            return connector.ConnectionState;
        }

    }
    
}
