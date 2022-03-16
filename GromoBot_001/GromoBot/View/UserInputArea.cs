using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal class UserInputArea
    {
        public void ToShow(Cursor cursor)
        {
            ToShowTitle(cursor);
            ToShowEndAreaSeparator(cursor);
            ToShowUserInputString(cursor);    
            ToShowEndAreaSeparator(cursor);
        }
        void ToShowTitle(Cursor cursor)
        {
            // Set cursor for title
            cursor.ToSetPosition(cursor.positionStore.leftIndentOfTitle, cursor.positionStore.lastRow);
            // Set Title's color
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Display title for UserInputArea
            Console.WriteLine(SignsOfMenuItemsStore.userInputTitle);
            // Save last position of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }
        void ToShowUserInputString(Cursor cursor)
        {
            // Set cursor for the string with state of parameters
            cursor.ToSetPosition(cursor.positionStore.leftIndentOfBody, cursor.positionStore.lastRow);
            Console.Write("Input:");
            // Write info about UserInputString to Store Of Cursor Position
            cursor.positionStore.inputOfUser = cursor.ToGetCursorPosition();
            Console.WriteLine();
            // Save last position of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
            
        }
        void ToShowEndAreaSeparator(Cursor cursor)
        {
            // Set position of cursor in a last position
            cursor.ToSetPosition(0, cursor.ToGetLastRowFromStore());
            // Choose a color for separator
            Console.ForegroundColor = ConsoleColor.DarkGray;
            // Take a separator symbols from store
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
            // Save last Row of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }

    }
}
