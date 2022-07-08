using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Areas;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Screens
{
    internal class MainMenuScreen : Screen
    {
        Cursor cursor;
        CursorPositionStore mainMenuCursorPositionStore;
        string titleName;

        public MainMenuScreen()
        {
            cursor = new Cursor();
            mainMenuCursorPositionStore = new CursorPositionStore();
            titleName = "MainMenuScreen";
        }
        public override string screenTitleName
        {
            get => titleName;
        }
        public override void ToShow()
        {
            cursor.ToSetInPosition(Screen.indentOfScreenTitle, cursor.currentPosition.numberOfRow);
            ToDisplayTitle();
            cursor.ToSavePosition();
            this.ToDispayInheritedAreas();
        }

        public override void ToDisplayTitle()
        {           
            Console.BackgroundColor = Screen.titleScreenColorBack;
            Console.ForegroundColor = Screen.titleScreenColorFront;
            Console.WriteLine(titleName);
        }
        public void ToDispayInheritedAreas()
        {
            ToShowMainMenuArea();
            ToShowStateParametersArea();
            ToShowUserInputArea();
            ToShowMessageArea();
            ToSetCursorInUserInputPlace();
        }
        void ToShowMainMenuArea()
        {
            MainMenuArea mainMenuArea = new MainMenuArea();
            cursor.ToSetInPosition(Area.indentOfAreaTitle, cursor.ToGetRowNumber(cursor.currentPosition));
            mainMenuArea.ToDisplayTitle();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaContent, cursor.ToGetRowNumber(cursor.currentPosition));
            mainMenuArea.ToDisplaySeparator();
            mainMenuArea.ToDisplayIems();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaContent, cursor.ToGetRowNumber(cursor.currentPosition));
            mainMenuArea.ToDisplaySeparator();
            cursor.ToSavePosition();
        }
        void ToShowStateParametersArea()
        {
            StateParameterArea stateParamArea = new StateParameterArea();
            cursor.ToSetInPosition(Area.indentOfAreaTitle, cursor.ToGetRowNumber(cursor.currentPosition));
            stateParamArea.ToDisplayTitle();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator,cursor.ToGetRowNumber(cursor.currentPosition));
            stateParamArea.ToDisplaySeparator();
            stateParamArea.ToDisplayStateParameters();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
            stateParamArea.ToDisplaySeparator();
            cursor.ToSavePosition();
        }
        void ToShowUserInputArea()
        {
            UserInputArea userInputArea = new UserInputArea();
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
            MessageArea messageArea = new MessageArea();
            cursor.ToSetInPosition(Area.indentOfAreaTitle, cursor.ToGetRowNumber(cursor.currentPosition));
            messageArea.ToDisplayTitle();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
            messageArea.ToDisplaySeparator();
            messageArea.ToDisplayMessageArray();
            cursor.ToSavePosition();
            cursor.ToSetInPosition(Area.indentOfAreaSeparator, cursor.ToGetRowNumber(cursor.currentPosition));
            messageArea.ToDisplaySeparator();
        }
        void ToSetCursorInUserInputPlace()
        {
            cursor.ToSetInPosition(mainMenuCursorPositionStore.userInputPosition);
        }
    }
}
