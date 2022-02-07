using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    class Cursor
    {
        public int left { get; private set; }
        public int top { get; private set; }

        internal void ToSetPosition (CursorPosition cursorPosition)
        {
            left = cursorPosition.numOfColumn;
            top = cursorPosition.numOfRow;
            Console.SetCursorPosition(top,left);
        }
    }
}
