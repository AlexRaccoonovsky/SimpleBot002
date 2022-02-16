using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Messages;
using StockSharp.BusinessEntities;

namespace GromoBot.Controller
{
    internal class GromoBot
    {
        public Modes currentMode { get; private set; } = Modes.MainMenuMode;
        public State currentState { get; private set; }
        public GromoBot()
        { 


        }

    }
}
