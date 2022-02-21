using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class Cursor
    {
        public int left { get; set; }
        public int top { get; set; }
        internal void ToSetPosition (CursorPosition cursorPosition)
        {
            top = cursorPosition.numOfRow;
            left = cursorPosition.numOfColumn;
            Console.SetCursorPosition(top,left);
        }

    }
}
