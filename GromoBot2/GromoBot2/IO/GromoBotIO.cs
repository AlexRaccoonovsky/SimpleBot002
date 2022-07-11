using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Screens;
using GromoBot2.IO.GromoMessages;


namespace GromoBot2.IO
{
    public class GromoBotIO
    {
        MainMenuScreen mainMenuScreen;
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
        void ToInitializeMainMenuScreen()
        {
            mainMenuScreen = new MainMenuScreen();
        }
        public void ToShowMainMenuScreen()
        {
            ToInitializeMainMenuScreen();
            mainMenuScreen.ToShow();
        }
        // Test method for check of displaying
        public void ToDisplayNewMessage(GromoMessage msg)
        {
            mainMenuScreen.ToShowNewMessage(msg);
        }
            
    }
}
