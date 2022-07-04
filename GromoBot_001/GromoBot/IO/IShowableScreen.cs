using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal interface IShowableScreen
    {
        const int indentOfScreenTitle = 20;
        const ConsoleColor screenTitleColor = ConsoleColor.Yellow;
        void ToShowScreenTitle();
    }
}
