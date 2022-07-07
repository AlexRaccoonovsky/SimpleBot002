using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.CursorParts
{
    internal class Cursor
    {
        CursorPosition position;
        public Cursor()
        {
            position = new CursorPosition(); 
        }
        public CursorPosition currentPosition
            { 
            get 
            { return position; }
            set
            { position = value; }
            }
        public void ToSavePosition()
        {
            int numRow = (Console.GetCursorPosition()).Top;
            int numCol = (Console.GetCursorPosition()).Left;
            position = new CursorPosition(numCol,numRow);
        }
        public void ToSetInPosition(CursorPosition position)
        {
            int left = position.numberOfColumn;
            int top = position.numberOfRow;
            Console.SetCursorPosition(left, top);
        }
        public void ToSetInPosition(int column, int row)
        { 
            Console.SetCursorPosition(column,row);
        }
        public int ToGetRowNumber(CursorPosition cursorPosition)
        {
            int rowNumber = cursorPosition.numberOfRow;
            return rowNumber;
        }
    }
}
