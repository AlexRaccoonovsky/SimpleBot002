using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot.Controller;

namespace GromoBot.View
{
    internal class MessageArea
    {
        public void ToShowNotice(Notice obj)
        {
            // Change Console color for Notice-message
            Console.ForegroundColor = ConsoleColor.Green;
            // Print DateTime prefix
            InsertDateTimePrefix();
            // Print message of Notice
            Console.WriteLine(obj.messageNotice);
        }
        public void ToShowTitle(Cursor cursor)
        {
            // Set cursor for title
            cursor.ToSetPosition(cursor.positionStore.leftIndentOfTitle, cursor.positionStore.lastRow);
            // Set Title's color
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Display title of MessageArea
            Console.WriteLine(SignsOfMenuItemsStore.messageAreaTitle);
            // Save last row of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
            // Display separator
            ToShowEndAreaSeparator(cursor);
        }
        void InsertDateTimePrefix()
        {
            Console.Write("[{0}]   |   ", DateTime.Now);
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
