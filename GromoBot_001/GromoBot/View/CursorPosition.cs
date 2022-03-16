using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot.View;

namespace GromoBot.View
{
    public class CursorPosition
    {
        public int numOfRow { get; set; }
        public int numOfColumn { get; set; }
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
    }
}
