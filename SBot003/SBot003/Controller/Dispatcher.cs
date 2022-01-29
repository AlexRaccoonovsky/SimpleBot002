using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.View;
using SBot003.DTO;
using SBot003.Model;
using SBot003.ServiceStorage;
using StockSharp.Messages; 


namespace SBot003.Controller
{
    public class Dispatcher
    {
        #region Auxiliary Entities definition
        MessagePresenter messagePresenter;
        UserInputHandler userInputHandler;
        GromoBotConnector gromoBotConnector;
        #endregion

        #region Indicators of Gromobot's State
        ConnectionStates connectionState = ConnectionStates.Disconnected;
        
        #endregion


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
            // Display MainMenu
            messagePresenter.ToShowMenu(MenuItemsStorage.mainMenuItems);
            // Take echo from User
            UserInput inputMainMenu = messagePresenter.ToTakeUserInput();
            // Rendering (Trimming+Parsing) UserInput object
            inputMainMenu = userInputHandler.ToRenderUserInput(inputMainMenu);
            // Executing UserCommand
            if (inputMainMenu.isValidRangeOfMenu)
            {

                // 
                ToExecuteMainMenuItem(inputMainMenu);
            }
            else
            // Throw the Alert
            {
                Alert incorrectInput = new Alert();
                incorrectInput.messageAlert = TxtMessageStorage.incorrectInput;
                messagePresenter.ToShowAlert(incorrectInput);
            }
        }
        void ToExecuteMainMenuItem(UserInput inputMainMenu)
        {
            switch (inputMainMenu.numChoice)
            {
                case 1:
                    Console.WriteLine("{0}", connectionState.ToString());
                    break;
                    case 2:
                    gromoBotConnector.ToConnect();
                    break;
                default:
                    break;
            }
        }
        StateNotice ToFormStateNotice(string txtStateSigns[], string[] valuesOfStatusSigns)
        {
            StateNotice obj = new StateNotice();
            for (int i=0;i<3;i++)
            {
                obj.txtStateSigns[i] = txtStateSigns[i];

            }
            return StateNotice obj;
        }
    }
}
