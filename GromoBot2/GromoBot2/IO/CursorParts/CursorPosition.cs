using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.CursorParts
{
    public class CursorPosition
    {
        byte numOfColumn { get; set; }
        byte numOfRow { get; set; }
        public CursorPosition() 
        { 
            numOfColumn = 0;
            numOfRow = 0;
        }
        public CursorPosition(byte column, byte row)
        {   
            numOfColumn = column;
            numOfRow = row;
        }
        public byte numberOfColumn
        { 
            get => numOfColumn; 
            set => numOfColumn = value;
        }
        public byte numberOfRow
        {
            get => numOfRow;
            set => numOfRow = value;
        }
    }
}
