using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Messages;
using StockSharp.BusinessEntities;

namespace GromoBot2.Controller
{
    public class StateOfGromo
    {
        public ConnectionStates connectionState { get; set; } = ConnectionStates.Disconnected;
        public Portfolio? selectedPortfolio { get; set; } = null;
        public Security? selectedSecurity { set; get; } = null;
        public StateOfGromo()
        {

        }
    }
}
