using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.DTO;
using SBot003.ServiceStorage;

namespace SBot003.Controller
{
     class UserInputHandler
    {
        internal UserInput ToRenderUserInput(UserInput obj)
        {
            // Take trimmed UserInput object
            obj = this.ToTrimUserInput(obj);
            // TryingToParse field strMessage(string) to numChoice(int) of InputUser
            UserInput userChoice = this.ToTryParse(obj);
            // Check conditions of range MenuItems
            obj=this.ToCheckRangeOfUserInput(obj);  
            return obj;

        }

        UserInput ToTrimUserInput(UserInput userInput)
        // Method trim spaces from property strMessage of UserInput
        {
            userInput.strMessage = (userInput.strMessage).Trim();
            return userInput;
        }

        UserInput ToTryParse(UserInput obj)
        {
            // numUserChoice - number of selected MenuItems by User
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
                // Return UserInput object with properties numChoice = null; isParsed = false; 
                return obj;
            }
        }
        UserInput ToCheckRangeOfUserInput(UserInput obj)
        {
            // TODO: Check a logic
            if (obj.numChoice !=null)
            {
                if (obj.numChoice >= RangeOfMenuStorage.minNumChoiceOfMainMenu &&
                    obj.numChoice <= RangeOfMenuStorage.maxNumChoiceOfMainMenu)
                { obj.isValidRangeOfMenu = true; }
                else
                { obj.isValidRangeOfMenu = false; }

                return obj;
            }
            else
            { return obj; }
        }

    }
}
