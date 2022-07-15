using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.GromoMessages;

namespace GromoBot2.Controller
{
    public class GromoStateEventArgs:EventArgs
    {
        public GromoMessage gromoMessage { get; private set; }
        public DateTime currentTime { get; private set; }

        public GromoStateEventArgs(GromoMessage msg)
        { 
            gromoMessage = msg;
            currentTime = DateTime.Now;
        }

    }
}
