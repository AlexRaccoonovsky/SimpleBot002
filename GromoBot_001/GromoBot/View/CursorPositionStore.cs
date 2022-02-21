using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public static class CursorPositionStore
    {
        public static CursorPosition nullPosition = new CursorPosition(0, 0);
        public static CursorPosition mainMenuTitle = new CursorPosition(0,10);
        public static CursorPosition titleStateParameters = new CursorPosition(11,10);
        public static CursorPosition titleUserInput = new CursorPosition(16,10);
        public static CursorPosition titleOfMessageArea = new CursorPosition(21,10);
        public static CursorPosition firstMessage = new CursorPosition(23,3);
        public static CursorPosition stateParametersString = new CursorPosition(12, 10);
        public static CursorPosition userInputPosition = new CursorPosition(18, 7);

    }
}
