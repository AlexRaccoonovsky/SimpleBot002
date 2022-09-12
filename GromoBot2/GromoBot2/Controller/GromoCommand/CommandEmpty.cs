using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.Controller.GromoCommand
{
    public class CommandEmpty : CommandForGromo
    {
        string nameCommand;
        GromoBot executor;
        public CommandEmpty(GromoBot gromoBot)
        {
            executor = gromoBot;
        }
        public override void ToExecute()
        {
            executor.ToEmptyAction();
        }
    }
}
