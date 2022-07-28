using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;

namespace GromoBot2.Controller.Mode
{
    public abstract class Mode
    {
        public abstract GromoBotIO gromoBotIO { get; set; }
        public abstract string Name { get; set; }
        public abstract StateOfGromo stateOfGromo { get; set; }
        public abstract void ToStart(ref GromoBotIO gromoIO, ref StateOfGromo currentGromoState);
        public abstract void ToInitializeEnvironment(GromoBotIO gromoIO, StateOfGromo currentGromoState);
    }
}
