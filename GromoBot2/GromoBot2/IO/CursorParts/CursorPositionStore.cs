using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.CursorParts
{
    public class CursorPositionStore
    {
        // TODO: ???? Need to refactor
        CursorPosition lastPos;
        CursorPosition userInputPos;
        CursorPosition bufferPos;
        CursorPosition gromoStatePos;
        CursorPosition mainMenuPos;
         
        public CursorPositionStore()
        {
            LastPosition = new CursorPosition(0, 0);

            userInputPosition = new CursorPosition(0, 0);
            bufferPos = new CursorPosition(0,0);
            gromoStatePos = new CursorPosition(0, 0);
            mainMenuPos = new CursorPosition(0, 0);
        }
        public CursorPosition LastPosition
        {
            get { return lastPos; }
            set { lastPos = value; }
        }
        public CursorPosition MainMenuPosition
        {
            get { return mainMenuPos; }
            set { mainMenuPos = value; }
        }
        public CursorPosition userInputPosition
        {
            get { return userInputPos; }
            set { userInputPos = value; }
        }
        public CursorPosition bufferMessagPosition
        {
            get { return bufferPos; }
            set { bufferPos = value; }
        }
        public CursorPosition gromoStatePosition
        {
            get { return gromoStatePos; }
            set { gromoStatePos = value; }
        }

    }
}
