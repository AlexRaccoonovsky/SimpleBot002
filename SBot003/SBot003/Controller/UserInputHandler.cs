using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.DTO;

namespace SBot003.Controller
{
     class UserInputHandler
    {
        internal UserInput ToRenderUserInput(UserInput obj)
        {
            // Take trimmed UserInput object
            obj = this.ToTrimUserInput(obj);
            // TryParse field strMessage to numChoice of InputUser
            UserInput userChoice = this.TryParse(obj);
            return obj;
        }

        UserInput ToTrimUserInput(UserInput userInput)
        // Method trim spaces from property strMessage of UserInput
        {
            userInput.strMessage = (userInput.strMessage).Trim();
            return userInput;
        }

        UserInput TryParse(UserInput obj)
        {
            byte numUserChoice;
            bool isSuccessParsing = byte.TryParse(obj.strMessage, out numUserChoice);
            if (isSuccessParsing)
            { 
                // Change properties numChoice & isParsed of object UserInput
                obj.numChoice = numUserChoice;
                obj.isParsed = true;
                return obj;
            }
            else
            {
                return obj;
            }
        }

    }
}
