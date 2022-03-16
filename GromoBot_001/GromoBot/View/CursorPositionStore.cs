using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class CursorPositionStore
    {
        public CursorPosition nullPosition { get; set; } = new CursorPosition();
        public CursorPosition lastPosition { get; private set;} = new CursorPosition();
        public CursorPosition inputOfUser { get; set; } = new CursorPosition();
        // TODO: const?
        public int leftIndentOfTitle = 8;
        public int leftIndentOfBody = 3;
        public int lastRow { get; private set; } = 0;
        public void ToSaveLastRow(int row)
        { 
            lastRow = row;
        }
        public void ToSaveLastPosition(int column, int row)
        { 
            lastPosition = new CursorPosition(column, row);
        }
        public void ToSaveLastPosition(CursorPosition position)
        {
            lastPosition= position;
        }
        // TODO: need? ToSaveInputOfUserPosition
        public void ToSaveInputOfUserPosition(CursorPosition position)
        {
            inputOfUser = position;
        }
    }
}
