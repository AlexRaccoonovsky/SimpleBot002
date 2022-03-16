using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class Cursor
    {
        int left { get; set; }
        int top { get; set; }
        CursorPosition cursorPosition;
        public CursorPositionStore positionStore;
        public Cursor()
        {
            left = 0;
            top = 0;    
            cursorPosition = new CursorPosition();
            positionStore=new CursorPositionStore();
        }
        internal void ToSetPosition (CursorPosition cursorPosition)
        {
            left = cursorPosition.numOfColumn;
            top = cursorPosition.numOfRow;
            Console.SetCursorPosition(left, top);
        }
        internal void ToSetPosition(int column, int row)
        {
            left = column;
            top = row;
            Console.SetCursorPosition(left, top);
        }
        internal CursorPosition ToGetCursorPosition()
        {
            return new CursorPosition(Console.CursorLeft, Console.CursorTop);
        }
        internal int ToGetLastRowFromStore()
        {
            return positionStore.lastRow;
        }

    }
}
