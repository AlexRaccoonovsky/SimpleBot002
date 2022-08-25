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
        public string InputText 
        {
            get { return textOfInput; }
            private set { textOfInput = value;}
        }
        public UserInput ToTake()
        {
            try
            {
                string input = Console.ReadLine();
                string inputTreated = ToTreatUserInput(input);
                InputText = inputTreated;
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            return this;
        }
        string ToTreatUserInput(string input)
        {
            string inputPure = "EmptyString";
            try
            {
                string inputTrimmed = input.Trim();
                inputPure = inputTrimmed.ToLower();
                return inputPure;
            }
            catch(Exception ex)
            {

            }
            finally
            {

                
            }

            return inputPure;


        }
    }
}
