using System;
using GromoBot2.Controller;
using GromoBot2.IO;

namespace GromoBot2
{
    class Program
    {
        static void Main(string[] args)
        {
            Gromo gromo = new Gromo();
            gromo.ToStartUp();
            Console.ReadKey();
        }
    }

}