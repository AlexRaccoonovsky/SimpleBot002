using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.View;
using SBot003.DTO;


namespace SBot003.Controller
{
    public class Dispatcher
    {
        MessagePresenter messagePresenter;
        UserInputHandler userInputHandler;

        public void StartToDispatch()
        {
            this.ToInitInvironment();
            messagePresenter.ShowMainMenu();
            // Take echo from User
            UserInput inputMainMenu = messagePresenter.TakeUserInput();
            // To Trim taking message
            UserInput userInputTrim = userInputHandler.ToTrimUserInput(inputMainMenu);
            // TryParse field strMessage to numChoice of inputuser
            UserInput userChoice = userInputHandler.TryParse(userInputTrim);
            if (userChoice.isParsed)
            {
                // ToValidateUserChoice
                Console.WriteLine("Parsing is complete");
            }
            else
            {

                Console.WriteLine("TryAgain!");
            }

        }

        internal void ToInitInvironment()
        {
            // Initialize MessagePresenter
            messagePresenter = new MessagePresenter();
            userInputHandler = new UserInputHandler();
        }

       //internal ToValidateUserChoice()
       //    {
       //    }



    }
}
