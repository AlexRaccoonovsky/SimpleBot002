using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot.View;

namespace GromoBot.View
{

    internal class MainMenuArea
    {
        int quanItemsMainMenu  = SignsOfMenuItemsStore.mainMenuItems.Length;

        public void ToShow(Cursor cursor, CursorPosition cursorPosition)
        {
            ToShowTitle(cursor, cursorPosition);
            cursor.ToSetPosition(cursorPosition.lastPosition);
            ToShowEndAreaSeparator(cursor, cursorPosition);
            ToShowMainMenuItems(cursor, cursorPosition);
            ToShowEndAreaSeparator(cursor, cursorPosition);
        }
        void ToShowTitle(Cursor cursor, CursorPosition cursorPosition)
        {
            // Set cursor to position of Main Menu Title
            cursor.ToSetPosition(CursorPositionStore.mainMenuTitle);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.mainMenuTitle);
            // Set field lastRowOfMessage of CursorPosition to current value
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
        void ToShowMainMenuItems(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            MenuItemStates[] accessTemplateOfMainMenu = AccessTemplatesStore.ToInitAccessTemplatePrimaryMainMenu();
              for (int numItem = 0; numItem< quanItemsMainMenu; numItem++)
              {
                  if (accessTemplateOfMainMenu[numItem] == MenuItemStates.Enable)
                  {
                      Console.ForegroundColor = ConsoleColor.White;
                      Console.WriteLine(SignsOfMenuItemsStore.mainMenuItems[numItem]);
                  }
                  else
                  {
                      Console.ForegroundColor = ConsoleColor.DarkGray;
                      Console.WriteLine(SignsOfMenuItemsStore.mainMenuItems[numItem]);
                  }
              }
            // Set field lastRowOfMessage of CursorPosition to current value
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
        void ToShowEndAreaSeparator(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
    }
}
