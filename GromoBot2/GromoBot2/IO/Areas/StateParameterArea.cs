using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Areas
{
    public class StateParameterArea:Area
    {
        string titleName = "StateParameterArea";
        string areaSeparator = "+++++++++++++++++++++++++++++++++++++";
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
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
        }
        public override void ToDisplaySeparator()
        {
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.WriteLine(areaSeparator);
        }
        public void ToDisplayStateParameters()
        {
            Console.WriteLine("+++STATEOFGROMO+++");
        }
    }
}
