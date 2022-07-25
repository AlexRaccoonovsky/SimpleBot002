using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.CursorParts
{
    public class Cursor
    {
        CursorPosition position;
    //    byte lastRow;
        public Cursor()
        {
            position = new CursorPosition(); 
    //        lastRow = 0;
        }
        public CursorPosition currentPosition
        { 
            get { return position; }
            set { position = value; }
        }
   //   public byte lastRow 
   //   { 
   //       get { return lastRow; }
   //       set { lastRow = value; }
   //   }
        public void ToSavePosition()
        {
            byte numRow = (byte)Console.GetCursorPosition().Top;
            byte numCol = (byte)Console.GetCursorPosition().Left;
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
        public void ToSetInPosition(byte column, byte row)
        {
            Console.SetCursorPosition(column, row);
        }
        public byte ToGetRowNumber(CursorPosition cursorPosition)
        {
            byte rowNumber = cursorPosition.numberOfRow;
            return rowNumber;
        }
        public byte ToGetLastRowNumber()
        {
            byte lastRowNumber;
            return lastRowNumber = ToGetRowNumber(currentPosition);
        }

    }
}
