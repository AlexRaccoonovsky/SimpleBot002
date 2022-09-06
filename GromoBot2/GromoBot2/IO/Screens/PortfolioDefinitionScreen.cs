using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Areas;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Screens
{
    public class PortfolioDefinitionScreen : Screen
    {
        string titleName;
        Cursor portfolioDefinitionCursor;
        CursorPositionStore portfolioDefinitionPositionStore;
        StateParameterArea stateParametersArea;
        UserInputArea userInputArea;
        MessageArea messageArea;
        public PortfolioDefinitionScreen()
        {
            titleName = "Portfolio Definition Screen";
            portfolioDefinitionCursor = new Cursor();
            portfolioDefinitionPositionStore = new CursorPositionStore();
            ToInitializeAreas();
        }
        void ToInitializeAreas()
        { 
            stateParametersArea = new StateParameterArea();
            userInputArea = new UserInputArea();
            messageArea = new MessageArea();
        }
        public override string screenTitleName
        { 
            get { return titleName; }
        }
        public override Cursor cursor
        { 
            get { return portfolioDefinitionCursor; }
        }
        public override CursorPositionStore cursorPositionStore
        {
            get { return portfolioDefinitionPositionStore; }
        }
        public override void ToDisplayTitle()
        {
            portfolioDefinitionCursor.ToSetInPosition(Screen.indentOfScreenTitle, cursor.currentPosition.NumberOfRow);
            Console.BackgroundColor = Screen.titleScreenColorBack;
            Console.ForegroundColor = Screen.titleScreenColorFront;
            Console.WriteLine(titleName);
            portfolioDefinitionCursor.ToSavePosition();
        }
        public override void ToShow()
        {
            ToDisplayTitle();
            this.ToDisplayInheritedAreas();
            this.ToSetCursorInUserInputPlace();
        }
        public override void ToRefreshStateArea()
        { }
        public override void ToHide()
        {
            Console.Clear();
        }
        void ToDisplayInheritedAreas()
        {
            ToShowStateParametersArea();
            ToShowUserInputArea();
            ToShowMessageArea();
        }
        void ToShowStateParametersArea()
        {
            stateParametersArea.areaCursor = portfolioDefinitionCursor;
            stateParametersArea.areaCursorPositionStore = cursorPositionStore;
            stateParametersArea.ToShow();
            portfolioDefinitionCursor = stateParametersArea.areaCursor;
            portfolioDefinitionPositionStore = stateParametersArea.areaCursorPositionStore;
        }
        void ToShowUserInputArea()
        {
            userInputArea.areaCursor = portfolioDefinitionCursor;
            userInputArea.areaCursorPositionStore = portfolioDefinitionPositionStore;
            userInputArea.ToShow();
            portfolioDefinitionCursor = userInputArea.areaCursor;
            portfolioDefinitionPositionStore = userInputArea.areaCursorPositionStore;
        }
        void ToShowMessageArea()
        { 
            messageArea.areaCursor = portfolioDefinitionCursor;
            messageArea.areaCursorPositionStore = portfolioDefinitionPositionStore;
            messageArea.ToShow();
            portfolioDefinitionCursor = messageArea.areaCursor;
            portfolioDefinitionPositionStore = messageArea.areaCursorPositionStore;
        }
        void ToSetCursorInUserInputPlace()
        {
            cursor.ToSetInPosition(portfolioDefinitionPositionStore.userInputPosition);
        }


    }
}
