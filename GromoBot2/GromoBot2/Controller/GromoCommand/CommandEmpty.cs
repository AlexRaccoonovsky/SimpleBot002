using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.Controller.GromoCommand
{
    public class CommandEmpty : CommandForGromo
    {
        GromoBot receiver;
        public CommandEmpty(GromoBot gromoBot)
        {
            receiver = gromoBot;
        }
        public override void ToExecute()
        {
            receiver.ToEmptyAction();
        }
    }
}
