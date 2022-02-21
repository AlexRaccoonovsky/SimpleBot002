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
        // TODO: Set default values to user input
        public int numOfRow { get; set; }
        public int numOfColumn { get; set; }
        public CursorPosition lastPosition { get; set; }

        public CursorPosition(int column, int row)
        {
            numOfColumn = column;
            numOfRow = row;
            lastPosition = CursorPositionStore.nullPosition;
        }
        public CursorPosition()
        {
            numOfColumn = 0;
            numOfRow = 0;
            lastPosition = CursorPositionStore.nullPosition;
        }
        internal void ToSetLastPosition(CursorPosition cursorPosition)
        {
            lastPosition.numOfRow = cursorPosition.numOfRow+1;
        }


    }
}
