using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    internal class UserInputArea
    {
        public void ToShow(Cursor cursor, CursorPosition cursorPosition)
        {
            ToShowTitle(cursor, cursorPosition);
            ToShowEndAreaSeparator(cursor, cursorPosition);
            ToShowUserInputString(cursor, cursorPosition);    
            ToShowEndAreaSeparator(cursor, cursorPosition);
        }
        void ToShowTitle(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.userInputTitle);
            // Set field lastRowOfMessage of CursorPosition to current value
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
        void ToShowUserInputString(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            Console.WriteLine("Input:");
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
        void ToShowEndAreaSeparator(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }

    }
}
