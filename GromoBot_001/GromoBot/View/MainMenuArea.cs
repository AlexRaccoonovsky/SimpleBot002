using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{

    internal class MainMenuArea
    {
          // TODO: Can kill ToSetTemplate()?
        internal void ToSetTemplate()
        { 
        }
        internal void ToShow(AccessTemplatesStore obj)
        {
            ToShowTitle();
            ToShowEndAreaSeparator();
            obj.ToInitAccessPrimaryMainMenu();
            for(int numItem = 0; numItem<obj.quanItemsMainMenu; numItem++)
            {
                if (obj.accessOfMainMenu[numItem] == TypeOfItems.Enable)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(SignsOfMenuItemsStore.mainMenuItems[numItem]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(SignsOfMenuItemsStore.mainMenuItems[numItem]);
                }
            }
            ToShowEndAreaSeparator();
        }
        void ToShowTitle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.mainMenuTitle);
        }
        void ToShowEndAreaSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
        }
    }
}
