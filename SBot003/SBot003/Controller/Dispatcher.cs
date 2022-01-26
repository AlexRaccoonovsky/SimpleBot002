using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.View;
using SBot003.DTO;
using SBot003.Model;


namespace SBot003.Controller
{
    public class Dispatcher
    {
        MessagePresenter messagePresenter;
        UserInputHandler userInputHandler;
        GromoBotConnector gromoBotConnector;
        void ToInitInvironment()
        {
            #region Initialize Entities for relationship
            messagePresenter = new MessagePresenter();
            userInputHandler = new UserInputHandler();
            gromoBotConnector = new GromoBotConnector();
            #endregion


        }

        public void StartToDispatch()
        {
            this.ToInitInvironment();
            messagePresenter.ToShowMainMenu();
            // Take echo from User
            UserInput inputMainMenu = messagePresenter.ToTakeUserInput();
            // Rendering (Trimming+Parsing) UserInput object
            inputMainMenu = userInputHandler.ToRenderUserInput(inputMainMenu);
            // To check Rendering UserInput
            bool isValidInputMainMenu = ToValidateRangeMainMenu(inputMainMenu);
            // Executing UserCommand
            if (inputMainMenu.isParsed && isValidInputMainMenu)
            {
                ToExecuteMainMenuItem(inputMainMenu);
            }
            else
            // Throw the Alert
            {
                Alert tryAgain = new Alert();
                tryAgain.messageAlert = TxtMessageStorage.messageTryAgain;
                messagePresenter.ShowAlert(tryAgain);
            }
        }
        // TODO: ToValidateRangeMainMenu
        bool ToValidateRangeMainMenu(UserInput obj)
        {
            return true;
        }
        void ToExecuteMainMenuItem(UserInput inputMainMenu)
        {
            switch (inputMainMenu.numChoice)
            {
                case 1:
                    gromoBotConnector.ToConnect();
                    break;
                default:
                    break;
            }
        }
    }
}
