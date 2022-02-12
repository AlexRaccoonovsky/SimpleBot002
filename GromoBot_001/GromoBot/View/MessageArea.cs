using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal class MessageArea
    {
        public void ToShowNotice()
        { }
        public void ToShowTitle()
        { 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.messageAreaTitle);
        }
    }
}
