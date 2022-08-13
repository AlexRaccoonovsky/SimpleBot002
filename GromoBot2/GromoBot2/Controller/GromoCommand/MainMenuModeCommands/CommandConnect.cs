using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.Controller;

namespace GromoBot2.Controller.GromoCommand.MainMenuModeCommand
{
    class CommandConnect:CommandForGromo
    {
        GromoBot receiver;
        public CommandConnect(GromoBot gromoBot)
        {
            receiver = gromoBot;
        }
        public override void Execute()
        {
            receiver.ToConnect();
        }
    }
}
