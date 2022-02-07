using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class CursorPosition
    {
        // TODO: Set default values to user input
        public int numOfColumn { get; private set; } = 0;
        public int numOfRow { get; private set; } = 0;
        
         public CursorPosition(int column, int row)
        {
            numOfColumn= column;
            numOfRow= row;
        }
    }
}
