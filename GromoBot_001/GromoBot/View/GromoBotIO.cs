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
        #endregion
        public GromoBotIO()
        {
            cursor = new Cursor();
            cursorPosition = new CursorPosition();
            mainMenuArea = new MainMenuArea();
            stateParametersArea = new StateParametersArea();
            userInputArea = new UserInputArea();
            messageArea = new MessageArea();
        }
        public void ToStartIO(State gromoState)
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
        void ToDrawInterfaceMainMenu(Cursor cursor, State gromoState)
        {
            mainMenuArea.ToShow(cursor, cursorPosition);
            stateParametersArea.ToShow(cursor, cursorPosition,gromoState);
            userInputArea.ToShow(cursor, cursorPosition);
            messageArea.ToShowTitle(cursor, cursorPosition);
       //  // Set cursor to UserInputPosition
       //  cursor.ToSetPosition(CursorPositionStore.userInputPosition);
        }
        public void ToShowNotice(Notice obj)
        {
            messageArea.ToShowNotice(obj);
        }

    }
}
