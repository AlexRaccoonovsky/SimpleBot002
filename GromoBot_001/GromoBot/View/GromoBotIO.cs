using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class GromoBotIO
    {
        #region Entities Of Input/Output Of Gromo
        internal MainMenu mainMenu;
        internal AccessTemplatesStore accessTemplatesStore;
        #endregion
        public void ToStartIO()
        {
            ToInitializeWindow();
            ToInitializeEntities();
            ToDrawInterfaceMainMenu();
            return;
        }
        void ToInitializeWindow()
        {
            // TODO: Set width & Height by max value
            Console.Title = "GromoBot";
            Console.BufferWidth = 120;
            Console.WindowWidth = Console.BufferWidth - 1;
            Console.BufferHeight = 50;
            Console.WindowHeight = Console.BufferHeight - 1;
            return;
        }
        void ToInitializeEntities()
        {
            mainMenu = new MainMenu();
            accessTemplatesStore = new AccessTemplatesStore();
            return;
        }
        void ToDrawInterfaceMainMenu()
        {
            // Set cursor to position of Main Menu Title
            Cursor cursor = new Cursor();
            cursor.ToSetPosition(CursorPositionStore.mainMenuTitle);
            // To depict Title Of MainMenu
            mainMenu.ToShowTitle();
            // Set cursor to position of first Main Menu Item
            cursor.ToSetPosition(CursorPositionStore.mainMenuItemsBegin);
            mainMenu.ToShowItems(accessTemplatesStore);

        }
    }
}
