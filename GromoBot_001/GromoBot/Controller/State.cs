using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Messages;
using StockSharp.BusinessEntities;

namespace GromoBot.Controller
{
    internal class State
    {
        ConnectionStates connectionState { get; set; } = ConnectionStates.Disconnected;
        Portfolio? selectedPortfolio { get; set; } = null;
        Security? selectedSecurity { set; get; } = null;

    }
}
