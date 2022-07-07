using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.CursorParts
{
    internal class CursorPosition
    {
        int numOfColumn { get; set; }
        int numOfRow { get; set; }
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
        public int numberOfColumn
        { 
            get => numOfColumn; 
            set => numOfColumn = value;
        }
        public int numberOfRow
        {
            get => numOfRow;
            set => numOfRow = value;
        }
    }
}
