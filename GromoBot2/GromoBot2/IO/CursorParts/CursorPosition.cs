using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.CursorParts
{
    public class CursorPosition
    {
        int numOfColumn;
        int numOfRow;
        public CursorPosition() 
        { 
            numOfColumn = 0;
            numOfRow = 0;
        }
        public CursorPosition(int column, int row)
        {   
            numOfColumn = column;
            numOfRow = row;
        }
        public int NumberOfColumn
        { 
            get { return numOfColumn; }
            set { numOfColumn = value; }
        }
        public int NumberOfRow
        {
            get { return numOfRow; }
            set { numOfRow = value; }

        }
    }
}
