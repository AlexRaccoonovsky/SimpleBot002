using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot.Controller;

namespace GromoBot.View
{
    public class GromoBotIO
    {
        #region Environment Of Input/Output Of Gromo
        MainMenuArea mainMenuArea;
        StateParametersArea stateParametersArea;
        UserInputArea userInputArea;
        MessageArea messageArea;
        // TODO: ??Resolve about accesmodificator
        Cursor cursor;
        CursorPosition cursorPosition;
        CursorPositionStore cursorCursorPositionStore;
        #endregion
        public GromoBotIO()
        {
            //cursorPosition = new CursorPosition();
            cursor = new Cursor();
            //cursorCursorPositionStore = new CursorPositionStore();
            mainMenuArea = new MainMenuArea();
            stateParametersArea = new StateParametersArea();
            userInputArea = new UserInputArea();
            messageArea = new MessageArea();
        }
        public void ToStartIO(StateOfGromo gromoState)
        {
            ToInitializeWindow();
            ToDrawInterfaceMainMenu(cursor, gromoState);
            return;
        }
        void ToInitializeWindow()
        {
            // TODO: Set width & Height by max value
            Console.Title = "GromoBot";
            Console.BufferWidth = 120;
            Console.WindowWidth = Console.BufferWidth - 1;
            Console.BufferHeight = 50;
            Console.WindowHeight = Console.BufferHeight - 1;
            return;
        }
        void ToDrawInterfaceMainMenu(Cursor cursor, StateOfGromo gromoState)
        {
            mainMenuArea.ToShow(cursor);
            stateParametersArea.ToShow(cursor, gromoState);
            userInputArea.ToShow(cursor);
            messageArea.ToShowTitle(cursor);
       //  // Set cursor to UserInputPosition
       //  cursor.ToSetPosition(CursorPositionStore.userInputPosition);
        }
        public void ToShowNotice(Notice obj)
        {
            messageArea.ToShowNotice(obj);
        }

    }
}
