using System;
using GromoBot.View
    ;

namespace GromoBot

{
    class Program
    {
        static void Main(string[] args)
        {
            
            GromoBotIO gromoBotIO = new GromoBotIO();   
            gromoBotIO.ToStartIO();
            Console.ReadKey();

        }
    }
}