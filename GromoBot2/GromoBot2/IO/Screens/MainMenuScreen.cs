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

        }

    }
}
