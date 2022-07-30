using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.Controller
{
    public class UserInput
    {
        string textOfInput;
        public string inputText 
        {
            get { return textOfInput; }
            set { textOfInput = value;}
        }
        public string ToTake()
        {
            string input = Console.ReadLine();
            input = this.ToTreatUserInput(input);
            return input;
        }
        private string ToTreatUserInput(string input)
        {
            string inputTrimmed = input.Trim();
            string inputPure = inputTrimmed.ToLower();
            return inputPure;
        }
    }
}
