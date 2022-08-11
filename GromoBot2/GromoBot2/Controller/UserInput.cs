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
            private set { textOfInput = value;}
        }
        public UserInput ToTake()
        {
            string input = Console.ReadLine();
            input = this.ToTreatUserInput(input);
            textOfInput = input;
            return this;
        }
        private string ToTreatUserInput(string input)
        {
            string inputTrimmed = input.Trim();
            string inputPure = inputTrimmed.ToLower();
            return inputPure;
        }
    }
}
