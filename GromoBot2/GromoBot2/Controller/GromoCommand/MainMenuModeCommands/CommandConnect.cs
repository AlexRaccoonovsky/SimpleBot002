using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.Controller.GromoCommand;

namespace GromoBot2.Controller.GromoCommand.MainMenuModeCommands
{
    public class CommandConnect:CommandForGromo
    {
        GromoBot receiver;
        public CommandConnect(GromoBot gromoBot)
        {
            receiver = gromoBot;
        }
        public override void ToExecute()
        {
            receiver.ToConnect();
        }
    }
}
