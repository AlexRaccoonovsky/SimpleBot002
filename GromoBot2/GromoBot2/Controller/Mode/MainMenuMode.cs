using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.Controller;


namespace GromoBot2.Controller.Mode
{
    class MainMenuMode
    {
        public void ToStart(ref GromoBotIO gromoIO)
        { 
            gromoIO.ToShowMainMenuScreen();
            UserInput userInput = new UserInput();
            userInput.inputText = Console.ReadLine();
        }

    }
}
