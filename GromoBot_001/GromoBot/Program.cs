using System;
using GromoBot.Controller;


namespace GromoBot

{
    class Program
    {
        static void Main(string[] args)
        {
            Gromo gromoBot = new Gromo();
            gromoBot.ToStartMainMenuMode();
            Console.ReadKey();

        }
    }
}