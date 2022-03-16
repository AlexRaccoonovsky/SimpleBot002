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

        public void ToShow(Cursor cursor)
        {
             ToShowTitle(cursor);
             ToShowEndAreaSeparator(cursor);
             ToShowMainMenuItems(cursor);
             ToShowEndAreaSeparator(cursor);
        }
        void ToShowTitle(Cursor cursor)
        {
             // Set cursor for title
            cursor.ToSetPosition(cursor.positionStore.leftIndentOfTitle, cursor.positionStore.nullPosition.numOfRow);
            // Set Title's color
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Display mainMenu title
            Console.WriteLine(SignsOfMenuItemsStore.mainMenuTitle);
            // Save last position of cursor to position's store
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }
        void ToShowMainMenuItems(Cursor cursor)
        {
            // Initialize primarily template of mainMenu's access
            MenuItemStates[] accessTemplateOfMainMenu = AccessTemplatesStore.ToInitAccessTemplatePrimaryMainMenu();
            // Display mainMenuItems with color scheme for access template
              for (int numItem = 0; numItem < quanItemsMainMenu; numItem++)
              {
                  if (accessTemplateOfMainMenu[numItem] == MenuItemStates.Enable)
                  {
                    // Choose a color by access template
                    Console.ForegroundColor = ConsoleColor.White;
                    // Take last position & set cursor
                    cursor.ToSetPosition(cursor.positionStore.leftIndentOfBody, cursor.ToGetLastRowFromStore());
                    // Type item from mainMenuItems-array
                    Console.WriteLine(SignsOfMenuItemsStore.mainMenuItems[numItem]);
                    // Save last position of cursor to position's store
                    cursor.positionStore.ToSaveLastRow(Console.CursorTop);
                }
                  else
                  {
                    // Choose a color by access template
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    // Take last position & set cursor
                    cursor.ToSetPosition(cursor.positionStore.leftIndentOfBody, cursor.ToGetLastRowFromStore());
                    // Type item
                    Console.WriteLine(SignsOfMenuItemsStore.mainMenuItems[numItem]);
                    // Save last position of cursor to position's store
                    cursor.positionStore.ToSaveLastRow(Console.CursorTop);
                }
              }
            // Save last position of cursor to position's store
            cursor.positionStore.ToSaveLastPosition(cursor.ToGetCursorPosition());
        }
        void ToShowEndAreaSeparator(Cursor cursor)
        {
            // Set position of cursor in a last position
            cursor.ToSetPosition(0, cursor.ToGetLastRowFromStore());
            // Choose a color for separator
            Console.ForegroundColor = ConsoleColor.DarkGray;
            // Take a separator symbols from store
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
            // Save last position of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }
    }
}
