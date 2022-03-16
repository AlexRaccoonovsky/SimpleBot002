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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.messageAreaTitle);
        }
        void InsertDateTimePrefix()
        {
            Console.Write("[{0}]   |   ", DateTime.Now);
        }
    }
}
