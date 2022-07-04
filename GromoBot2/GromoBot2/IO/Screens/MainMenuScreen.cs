using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Areas;

namespace GromoBot2.IO.Screens
{
    internal class MainMenuScreen : Screen
    {
        string titleName = "MainMenuScreen";
        public override string screenTitleName
        {
            get => titleName;
            // set => titleName = value;
        }

        public override void ToDisplayTitle()
        {
            Console.SetCursorPosition(Screen.indentOfScreenTitle, 0);
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
            mainMenuArea.ToDisplayTitle();
            mainMenuArea.ToDisplaySeparator();

        }

    }
}
