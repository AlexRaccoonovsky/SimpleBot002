using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Areas
{
    public class UserInputArea:Area
    {
        string titleName = "UserInputArea";
        string areaSeparator = "-------------------------------------";
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
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
        }
        public override void ToDisplayTitle()
        {
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
        }
        public void ToDisplayUserInputString()
        {
            Console.Write("User Input:");
        }

    }                          
}
