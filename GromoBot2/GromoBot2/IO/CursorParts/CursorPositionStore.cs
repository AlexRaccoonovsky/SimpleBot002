using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.CursorParts
{
    internal class CursorPositionStore
    {
        // TODO: Need to refactor?
        CursorPosition lastPos;
        CursorPosition userInputPos;
        public CursorPosition lastPosition
        {
            get => lastPos;
            set => lastPos = value;
        }
        public CursorPosition userInputPosition
        {
            get => userInputPos;
            set => userInputPos = value;
        }
        public CursorPositionStore()
        {
            lastPosition = new CursorPosition(0, 0);
            userInputPosition = new CursorPosition(0, 0);
        }


    }
}
