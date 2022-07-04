using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.Controller.Mode;

namespace GromoBot2.Controller
{
    public class Gromo
    {
        GromoBotIO gromoIO;
        public StateOfGromo currentState { get; private set; }
        public Gromo()
        { 
            gromoIO = new GromoBotIO();
        }

        public void ToStartUp()
        {
            MainMenuMode mainMenuMode = new MainMenuMode();
            mainMenuMode.ToStart(ref gromoIO);

        }
    }
}
