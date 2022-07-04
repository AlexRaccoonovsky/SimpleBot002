using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Screens
{
    internal interface IScreen
        // !!! Unusing interface, change on abstract class Screen
    {
        const int indentOfScreenTitle = 20;
        const ConsoleColor screenTitleColor = ConsoleColor.Yellow;
        string screenTitleName { set; get; }
        void ToDisplayScreenTitle();

    }
}
