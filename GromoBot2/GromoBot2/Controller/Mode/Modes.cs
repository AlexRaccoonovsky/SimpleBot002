using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;

namespace GromoBot2.Controller.Mode
{
    public abstract class Modes
    {
        //public abstract GromoBotIO gromoBotIO { get; set; }
        public abstract string Name { get; }
       // public abstract StateOfGromo stateOfGromo { get; set; }
        public abstract void ToStart(GromoBot bot);
        //public abstract void ToInitializeEnvironment(GromoBotIO gromoIO, StateOfGromo currentGromoState);
    }
}
