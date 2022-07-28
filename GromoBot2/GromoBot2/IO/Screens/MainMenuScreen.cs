using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Areas;
using GromoBot2.IO.CursorParts;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;

namespace GromoBot2.IO.Screens
{
    internal class MainMenuScreen : Screen
    {
        string titleName;
        Cursor mainMenuScreenCursor;
        CursorPositionStore mainMenuCursorPositionStore;
        MainMenuArea mainMenuArea;
        StateParameterArea stateParametersArea;
        UserInputArea userInputArea;
        MessageArea messageArea;


        public MainMenuScreen()
        {
            titleName = "MainMenuScreen";
            mainMenuScreenCursor = new Cursor();
            mainMenuCursorPositionStore = new CursorPositionStore();
            ToInitializeAreas();
        }
        void ToInitializeAreas()
        {
            mainMenuArea = new MainMenuArea();
            stateParametersArea = new StateParameterArea();
            userInputArea = new UserInputArea();
            messageArea = new MessageArea();

        }
        public override string screenTitleName
        {
            get => titleName;
        }
        public override CursorPositionStore cursorPositionStore
        {
            get => mainMenuCursorPositionStore;
        }
        public override Cursor cursor
        { 
            get => mainMenuScreenCursor;
        }
        public override void ToShow()
        {
            ToDisplayTitle();
            this.ToDispayInheritedAreas();
            
            this.ToSetCursorInUserInputPlace();
        }

        public override void ToDisplayTitle()
        {
            mainMenuScreenCursor.ToSetInPosition(Screen.indentOfScreenTitle, cursor.currentPosition.numberOfRow);
            Console.BackgroundColor = Screen.titleScreenColorBack;
            Console.ForegroundColor = Screen.titleScreenColorFront;
            Console.WriteLine(titleName);
            mainMenuScreenCursor.ToSavePosition();
        }
        void ToDispayInheritedAreas()
        {
            ToShowMainMenuArea();
            ToShowStateParametersArea();
            ToShowUserInputArea();
            ToShowMessageArea();
        }
        void ToShowMainMenuArea()
        {
            mainMenuArea.areaCursor = mainMenuScreenCursor;
            mainMenuArea.areaCursorPositionStore = mainMenuCursorPositionStore;
            mainMenuArea.ToShow();
            mainMenuScreenCursor = mainMenuArea.areaCursor;
            mainMenuCursorPositionStore = mainMenuArea.areaCursorPositionStore;

        }
        void ToShowStateParametersArea()
        {
            stateParametersArea.areaCursor = mainMenuScreenCursor;
            stateParametersArea.areaCursorPositionStore = mainMenuCursorPositionStore;
            stateParametersArea.ToShow();
            mainMenuScreenCursor = stateParametersArea.areaCursor;
            mainMenuCursorPositionStore = stateParametersArea.areaCursorPositionStore;
        }
        void ToShowUserInputArea()
        {
            userInputArea.areaCursor = mainMenuScreenCursor;
            userInputArea.areaCursorPositionStore= mainMenuCursorPositionStore;
            userInputArea.ToShow();
            mainMenuScreenCursor = userInputArea.areaCursor;
            mainMenuCursorPositionStore = userInputArea.areaCursorPositionStore;
        }
        void ToShowMessageArea()
        {
            messageArea.areaCursor= mainMenuScreenCursor;
            messageArea.areaCursorPositionStore= mainMenuCursorPositionStore;
            messageArea.ToShow();
            mainMenuScreenCursor = messageArea.areaCursor;
            mainMenuCursorPositionStore = messageArea.areaCursorPositionStore;
        }
        void ToSetCursorInUserInputPlace()
        {
            cursor.ToSetInPosition(mainMenuCursorPositionStore.userInputPosition);
        }
        public void ToShowNewMessage(GromoMessage newMessage)
        {
            messageArea.ToAddUpBuffer(newMessage);
            mainMenuScreenCursor.ToSetInPosition(mainMenuCursorPositionStore.bufferMessagPosition);
            messageArea.ToCleanUp();
            mainMenuScreenCursor.ToSetInPosition(mainMenuCursorPositionStore.bufferMessagPosition);
            messageArea.ToDisplayBuffer();
            this.ToSetCursorInUserInputPlace();
        }
        // Temporary method for display Gromo state
        public void ToRefreshGromoState(StateOfGromo state)
        {
            stateParametersArea.ToRefreshStateParameters(state);
            this.ToSetCursorInUserInputPlace();
        }
        // TODO: Dispose objects & CLS - operator info
        //public override void ToClose();
    }
}
