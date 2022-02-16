using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal class UserInputArea
    {
        public void ToShow()
        {
            ToShowTitle();
            ToShowEndAreaSeparator();
            ToShowUserInputString();    
            ToShowEndAreaSeparator();
        }
        void ToShowTitle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.userInputTitle);
        }
        void ToShowUserInputString()
        {
            Console.WriteLine("Input:");
        }
        void ToShowEndAreaSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
        }

    }
}
