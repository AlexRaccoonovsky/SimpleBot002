using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;
using GromoBot2.Controller.GromoCommand;
using GromoBot2.IO.Areas;
using GromoBot2.GromoExceptions.ControllerExceptions;




namespace GromoBot2.Controller.Mode
{
    public class MainMenuMode:Modes
    {
        string nameOfMode;
        GromoBot gromoBot;
        GromoBotIO IO;
        StateOfGromo stateGromo;
        CommandForGromo command;
        
        public override string Name 
        {
            get { return nameOfMode; }
        }
        void ToInitializeEnvironment(GromoBot gromo)
        {
            nameOfMode = "MainMenuMode";
            gromoBot = gromo;
            IO = gromo.gromoBotIO;
            stateGromo = gromo.gromoState;
            command = new CommandEmpty(gromo);
        }
        public void ToStartFirstTime(GromoBot gromo)
        { 
            gromo.CurrentMode = new MainMenuMode();
            ToInitializeEnvironment(gromo);
            IO.ToShowMainMenuScreen();
            IO.ToDisplayGromoState(stateGromo);
            MenuItemsState[] templateForMenuItems = ToDefineTemplateBy(stateGromo);
            Notice Welcome = new Notice(StoreTextsOfNotices.Welcome);
            IO.ToDisplayNewMessage(Welcome);


    //        int numOfInput = this.ToTakeMainMenuInput();
   //     
   //     if (IsValidInput(numOfInput))
   //     {
   //        command = gromoBot.ToConvertIntoCommand(numOfInput);
   //     }
   //     else
   //     {
   //         Alert invalidInput = new Alert(StoreTextsOfAlert.InvalidInput);
   //         IO.ToDisplayNewMessage(invalidInput);
   //     }
   //     command.ToExecute();
        }
        public override void ToStart(GromoBot gromo)
        { }
   // int ToTakeMainMenuInput()
   // {
   //     // TODO: Refactor this method
   //     int numOfUserInput = 0;
   //     try
   //     {
   //         MainMenuInputPrev userInput = new UserInputPrev();
   //         userInput.ToTake();
   //         numOfUserInput = Int32.Parse(userInput.InputText);
   //     }
   //     catch (Exception ex)
   //     {
   //         Alert errorOfInput = new Alert(StoreTextsOfAlert.ErrorOfInputMainMenu);
   //         IO.ToDisplayNewMessage(errorOfInput);
   //     }
   //     finally 
   //     { 
   //
   //     }
   //     return numOfUserInput;
   // }
        bool IsValidInput(int input)
        {
            try
                // TODO: !!!Define validation procedure like a list
            {

            }
            catch (Exception e)
            {  }
            finally
            { }
            
            MenuItemsState[] currentTemplate = IO.ToGetTemplateForMainMenuScreen();
            if (currentTemplate[input - 1] == MenuItemsState.Enabled)
                return true;
            else
                return false;

        }
        MenuItemsState[] ToDefineTemplateBy(StateOfGromo state)
        {
            MenuItemsState[] definedTemplate = TemplatesOfMenuItems.AwaitingTemplate; ;
            try
            {
                if (stateGromo.ConnectionState == StockSharp.Messages.ConnectionStates.Disconnected)
                {
                    definedTemplate = TemplatesOfMenuItems.StartUpTemplate;
                    return definedTemplate;
                }
                if (state.ConnectionState == StockSharp.Messages.ConnectionStates.Connecting)
                {
                    definedTemplate = TemplatesOfMenuItems.AwaitingTemplate;
                    return definedTemplate;
                }
                if (state.ConnectionState == StockSharp.Messages.ConnectionStates.Connected)
                {
                    definedTemplate = TemplatesOfMenuItems.TemplateConnected;
                    return definedTemplate;
                }
                // TODO: throw new MainMenuTemplateDefinitionException()
            }
            catch (Exception ex)
            { }
            finally
            { }
            return definedTemplate;
        }
    }
}
