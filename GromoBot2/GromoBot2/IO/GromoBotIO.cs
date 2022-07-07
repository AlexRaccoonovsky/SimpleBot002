using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Screens;

namespace GromoBot2.IO
{
    public class GromoBotIO
    {
        public Screen? currentScreen;
        public GromoBotIO()
        { 
            this.ToInitializeWindow();
        }
        void ToInitializeWindow()
        {
            // TODO: Set width & Height by max value
            Console.Title = "GromoBot";
            Console.BufferWidth = 120;
            Console.WindowWidth = Console.BufferWidth - 1;
            Console.BufferHeight = 50;
            Console.WindowHeight = Console.BufferHeight - 1;
            return;
        }
        public void ToShowMainMenuScreen()
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.ToShow();

        }
    }
}
