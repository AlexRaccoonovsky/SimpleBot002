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

        #region Parameters of Gromobot's State
        // Quantity of Gromobot's parameters:
        // - connectionState;
        // - selectedPortfolio;
        // - selectedSecurity.
        public const int numOfGromoBotParameters = 3;
        // Initiation of GromoBot's parameters
        ConnectionStates connectionState = ConnectionStates.Disconnected;
        string selectedPortfolio = "EmptyPortfolio";
        string selectedSecurity = "EmptySecurity";
        #endregion

        void ToInitInvironment()
        {
            #region To Initialize Entities for relationship
            messagePresenter = new MessagePresenter();
            userInputHandler = new UserInputHandler();
            gromoBotConnector = new GromoBotConnector();
            #endregion

            #region Registration Events of GromoBotConnector
            // Events registration
            gromoBotConnector.EventConnected += HandlerEventConnected;
            //connector.Connected += ToNotifyDispatcherConnected;
            // Delegates registrtion
            #endregion
        }
        public void StartToDispatch()
        {
            this.ToInitInvironment();
            this.HandlerMainMenu();
        }
        void ToExecuteMainMenuItem(UserInput inputMainMenu)
        {
            switch (inputMainMenu.numChoice)
            {
                    case 1:
                    // TODO: !!!For refactor: In one method
                    string[] valuesOfStateParams = new string[numOfGromoBotParameters];
                    valuesOfStateParams [0] = connectionState.ToString();
                    valuesOfStateParams [1] = selectedPortfolio; 
                    valuesOfStateParams [2] = selectedSecurity;
                    //
                    StateNotice currentState = new StateNotice(valuesOfStateParams);
                    //
                    messagePresenter.ToShowStateNotice(currentState);
                    
                    Notice pressEnterKey = new Notice();
                    pressEnterKey.messageNotice = TxtMessageStorage.pressEnterNotice;
                    messagePresenter.ToShowNotice(pressEnterKey);
                    if (messagePresenter.IsPressedEnter())
                       { HandlerMainMenu();}
                    break;

                    case 2:

                    // Show current state


                    gromoBotConnector.ToConnect();

                    Notice nowState = new Notice();
                    this.connectionState = gromoBotConnector.ToCheckConnectionState();
                    nowState.messageNotice = connectionState.ToString();
                    messagePresenter.ToShowNotice(nowState);
                    messagePresenter.ToTakeUserInput();


                    break;

                    default:
                    break;
            }
        }
        void HandlerMainMenu()
        {
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
        void HandlerEventConnected(object source,EventArgs arg)
        {
            Notice nowState = new Notice();
            this.connectionState = gromoBotConnector.ToCheckConnectionState();
            nowState.messageNotice = connectionState.ToString();
            messagePresenter.ToShowNotice(nowState);
            messagePresenter.ToTakeUserInput();


        }

    }
}
