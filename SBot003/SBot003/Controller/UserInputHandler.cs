using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.DTO;

namespace SBot003.Controller
{
    internal class UserInputHandler
    {
        internal UserInput ToTrimUserInput(UserInput userInput)
        {
            userInput.strMessage = (userInput.strMessage).Trim();
            return userInput;
        }

        internal UserInput TryParse(UserInput userChoice)
        {
            byte numUserChoice;
            bool success = byte.TryParse(userChoice.strMessage, out numUserChoice);
            if (success)
            {
                userChoice.numChoice = numUserChoice;
                userChoice.isParsed = true;
                return userChoice;
            }
            else

                return userChoice;
        }

    }
}
