using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.Controller.GromoCommand.MainMenuModeCommands
{
    public class CommandToDefinePortfolio:CommandForGromo
    {
        GromoBot receiver;
        public CommandToDefinePortfolio(GromoBot gromobot)
        { 
            receiver = gromobot;
        }
        public override void ToExecute()
        {
            receiver.ToDefinitePortfolio();
        }

    }
}
