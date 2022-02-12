using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal class StateParametersArea
    {
        public void ToShow()
        {
            ToShowTitle();
            ToShowEndAreaSeparator();
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("ConnectionState: {0} | Portfolio: {1} | Security: {2}","CS","MyPortf","MySec");
            ToShowEndAreaSeparator();
        }
        void ToShowTitle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.stateParametersTitle);
        }
        void ToShowEndAreaSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
        }
    }
}
