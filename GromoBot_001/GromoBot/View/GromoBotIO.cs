using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public class GromoBotIO
    {
        #region Entities Of Input/Output Of Gromo
        MainMenuArea mainMenuArea;
        StateParametersArea stateParametersArea;
        AccessTemplatesStore accessTemplatesStore;
        UserInputArea userInputArea;
        MessageArea messageArea;
        // TODO: ??Resolve about accesmodificator
        internal Cursor cursor;
        internal CursorPosition cursorPosition;
        #endregion
        public void ToStartIO()
        {
            ToInitializeWindow();
            ToInitializeEntities();
            ToDrawInterfaceMainMenu();
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
        void ToInitializeEntities()
        {
            cursor = new Cursor();
            cursorPosition = new CursorPosition();
            accessTemplatesStore = new AccessTemplatesStore();
            mainMenuArea = new MainMenuArea();
            stateParametersArea = new StateParametersArea();
            userInputArea = new UserInputArea();
            messageArea = new MessageArea();    
            return;
        }
        void ToDrawInterfaceMainMenu()
        {
            // TODO: May be cursor transfer to AreaMdules?
            // Set cursor to position of first Main Menu Item
            cursor.ToSetPosition(CursorPositionStore.mainMenuTitle);
            mainMenuArea.ToShow(accessTemplatesStore);
            // Set cursor to position of GromoBot's State Parameters
            cursor.ToSetPosition(CursorPositionStore.titleStateParameters);
            stateParametersArea.ToShow();
            // Set cursor to position of GromoBot's UserInput
            cursor.ToSetPosition(CursorPositionStore.titleUserInput);
            userInputArea.ToShow();
            // Set cursor to MessageArea position of GromoBot
            cursor.ToSetPosition(CursorPositionStore.titleOfMessageArea);
            messageArea.ToShowTitle();
            // Set cursor to UserInputPosition
            cursor.ToSetPosition(CursorPositionStore.userInputPosition);
        }
    }
}
