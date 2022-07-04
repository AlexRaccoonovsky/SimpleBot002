using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;


namespace GromoBot2.Controller.Mode
{
    class MainMenuMode
    {
        public void ToStart(ref GromoBotIO gromoIO)
        { 
            gromoIO.ToShowMainMenuScreen();
        }

    }
}
