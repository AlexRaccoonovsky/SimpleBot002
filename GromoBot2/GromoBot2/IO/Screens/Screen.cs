using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Screens
{
    public abstract class Screen
    {
        public const int indentOfScreenTitle = 50;
        public const ConsoleColor titleScreenColorFront = ConsoleColor.Yellow;
        public const ConsoleColor titleScreenColorBack = ConsoleColor.DarkGreen;
        public abstract string screenTitleName { get; }
        public abstract void ToDisplayTitle();
    }
}
