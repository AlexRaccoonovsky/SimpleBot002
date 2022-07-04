using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal interface IShowableArea
    {
        const int indentOfAreaTitle = 15;
        const int indentOfItems = 9;
        const int indentOfSeparator = 5;
        const ConsoleColor areaTitleColor = ConsoleColor.Magenta;

        void ToShowSeparator();
        void ToShowAreaTitle();
    }
}
