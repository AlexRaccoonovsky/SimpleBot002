using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Areas
{
    public class MainMenuArea:Area
    {
        string titleName = "MainMenuArea";
        string areaSeparator = "*************************************";
        public override string areaTitleName
        {
            get => titleName;
        }
        public override string areaSeparatorType
        {
            get => areaSeparator;
        }
        public override void ToDisplayTitle()
        {
            Console.SetCursorPosition(Area.indentOfAreaTitle, 1);
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
        }
        public override void ToDisplaySeparator()
        {
            Console.SetCursorPosition(indentOfAreaSeparator, 2);
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
        }
    }
}
