using System;
using GromoBot2.Controller;
using GromoBot2.Controller.Mode;

namespace GromoBot2
{
    class Program
    {
        static void Main(string[] args)
        {
            GromoBot gromo = new GromoBot();
            MainMenuMode mainMenuMode = new MainMenuMode();
            mainMenuMode.ToStartFirstTime(gromo);
            Console.ReadKey();
        }
    }

}