using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Areas;
using GromoBot2.IO.CursorParts;
using GromoBot2.IO.GromoMessages;

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
            ToSetCursorInUserInputPlace();
        }
        void ToShowMainMenuArea()
        {
            mainMenuArea.areaCursor = mainMenuScreenCursor;
            mainMenuArea.areaCursorPositionStore = mainMenuCursorPositionStore;
            //mainMenuArea.ToDesignateCursorParts(mainMenuScreenCursor, mainMenuCursorPositionStore);
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
            //cursor.ToSetInPosition(Area.indentOfAreaTitle, cursor.ToGetRowNumber(cursor.currentPosition));
         // stateParametersArea.ToDisplayTitle();
         // cursor.ToSavePosition();
         // cursor.ToSetInPosition(Area.indentOfAreaSeparator,cursor.ToGetRowNumber(cursor.currentPosition));
         // stateParametersArea.ToDisplaySeparator();
         // stateParametersArea.ToDisplayStateParameters();
         // cursor.ToSavePosition();
         // cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
         // stateParametersArea.ToDisplaySeparator();
         // cursor.ToSavePosition();
        }
        void ToShowUserInputArea()
        {
            cursor.ToSetInPosition(Area.indentOfAreaTitle,cursor.ToGetRowNumber(cursor.currentPosition)); 
            userInputArea.ToDisplayTitle();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
            userInputArea.ToDisplaySeparator();
            userInputArea.ToDisplayUserInputString();
            cursor.ToSavePosition();
            mainMenuCursorPositionStore.userInputPosition = cursor.currentPosition;
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition)+1);
            userInputArea.ToDisplaySeparator();
            cursor.ToSavePosition();
        }
        void ToShowMessageArea()
        {
            cursor.ToSetInPosition(Area.indentOfAreaTitle, cursor.ToGetRowNumber(cursor.currentPosition));
            messageArea.ToDisplayTitle();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
            messageArea.ToDisplaySeparator();
            cursor.ToSavePosition();
            mainMenuCursorPositionStore.bufferMessagPosition = cursor.currentPosition;
            messageArea.ToDisplayBuffer();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
            messageArea.ToDisplaySeparator();
        }
        void ToSetCursorInUserInputPlace()
        {
            cursor.ToSetInPosition(mainMenuCursorPositionStore.userInputPosition);
        }
        public void ToShowNewMessage(GromoMessage newMessage)
        {
            cursor.ToSetInPosition(Screen.indentOfScreenString, cursor.ToGetRowNumber(mainMenuCursorPositionStore.bufferMessagPosition));
            messageArea.ToCleanUp();
            cursor.ToSetInPosition(Screen.indentOfScreenString, cursor.ToGetRowNumber(mainMenuCursorPositionStore.bufferMessagPosition));
            messageArea.ToAddUpBuffer(newMessage);
            messageArea.ToDisplayBuffer();
            //cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(mainMenuCursorPositionStore.bufferMessagPosition));

            //cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(mainMenuCursorPositionStore.bufferMessagPosition));
            //messageArea.ToShowBuffer();
        }
        // TODO: Dispose objects & CLS - operator info
        //public override void ToClose();
    }
}
