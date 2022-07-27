using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Areas
{
    public class UserInputArea:Area
    {
        string titleName = "UserInputArea";
        string areaSeparator = "-------------------------------------";
        Cursor userInputAreaCursor;
        CursorPositionStore userInputAreaCursorPositionStore;
        public UserInputArea()
        {
            userInputAreaCursor = new Cursor();
            userInputAreaCursorPositionStore = new CursorPositionStore();
        }
        public override Cursor areaCursor
        {
            get { return userInputAreaCursor; }
            set { userInputAreaCursor = value; }
        }
        public override CursorPositionStore areaCursorPositionStore
        {
            get { return userInputAreaCursorPositionStore; }
            set { userInputAreaCursorPositionStore = value; }
        }
        public override string areaTitleName
        {
            get => titleName;
        }
        public override string areaSeparatorType
        {
            get => areaSeparator;
        }
        
        public override void ToDisplaySeparator()
        {
            byte lastRow = userInputAreaCursor.ToGetLastRowNumber();
            userInputAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator, lastRow);   
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
            userInputAreaCursor.ToSavePosition();
        }
        public override void ToDisplayTitle()
        {
            byte lastRow = userInputAreaCursor.ToGetLastRowNumber();
            userInputAreaCursor.ToSetInPosition(Area.indentOfAreaTitle,lastRow);
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
            userInputAreaCursor.ToSavePosition();
        }
        void ToDisplayUserInputString()
        {
            byte lastRow = userInputAreaCursor.ToGetLastRowNumber();
            userInputAreaCursor.ToSetInPosition(Area.indentOfAreaContent, lastRow);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User Input:");
            userInputAreaCursor.ToSavePosition();
            userInputAreaCursorPositionStore.userInputPosition = userInputAreaCursor.currentPosition;
            Console.WriteLine();
            userInputAreaCursor.ToSavePosition();
        }
        public void ToShow()
        {
            this.ToDisplaySeparator();
            this.ToDisplayTitle();
            this.ToDisplaySeparator();
            this.ToDisplayUserInputString();
            this.ToDisplaySeparator();
        }

    }                          
}
