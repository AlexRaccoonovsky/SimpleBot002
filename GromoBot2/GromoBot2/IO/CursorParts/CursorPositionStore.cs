using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.CursorParts
{
    public class CursorPositionStore
    {
        // TODO: Need to refactor?
        CursorPosition lastPos;
        CursorPosition userInputPos;
        CursorPosition bufferPos;
        public CursorPositionStore()
        {
            lastPosition = new CursorPosition(0, 0);
            userInputPosition = new CursorPosition(0, 0);
        }
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
        public CursorPosition bufferMessagPosition
        {
            get { return bufferPos; }
            set { bufferPos = value; }
        }



    }
}
