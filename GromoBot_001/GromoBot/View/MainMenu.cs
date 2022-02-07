using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class MainMenu
    {
        internal void ToShowTitle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.mainMenuTitle);
        }

        internal void ToSetTemplate()
        { 
        }
        
        internal void ToShowItems(AccessTemplatesStore obj)
        {
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


        }
    }
}
