using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Areas
{
    public class MessageArea:Area
    {
        string titleName = "Message Area";
        string areaSeparator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        int rowsNumOfArea = 10;
        string[] messageArray = new string[3];
        string[] messageArrayTest = { "Hello", "From", "GromoBot!" };
        public override string areaTitleName
        {
            get => titleName;
        }
        public override string areaSeparatorType
        {
            get => areaSeparator;
        }
        public int rowsNumberOfArea 
        { 
            get
            {
                return rowsNumOfArea;
            }
            set
            {
                rowsNumOfArea = value;
            }
        }
        public override void ToDisplayTitle()
        {
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.WriteLine(titleName);
        }
        public override void ToDisplaySeparator()
        {
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparatorType);
        }
        public void ToDisplayMessageArray()
        {
            Console.WriteLine("MessageArray");
        }
    }
}
