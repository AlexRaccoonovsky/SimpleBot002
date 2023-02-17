using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.IO.UserInput;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;
using GromoBot2.Controller.GromoCommand;
using GromoBot2.IO.Areas;
using GromoBot2.GromoExceptions.ControllerExceptions;
using GromoBot2.GromoExceptions;




namespace GromoBot2.Controller.Mode
{
    public class MainMenuMode:Mode
    {
        string nameOfMode;
        GromoBot gromoBot;
        GromoBotIO IO;

        MainMenuUserInput userInput;

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
            gromo.CurrentMode = new MainMenuMode();
        }
        public void ToStartFirstTime(GromoBot gromo)
        { 
            
            ToInitializeEnvironment(gromo);
            IO.ToShowMainMenuScreen();
            
            IO.ToDisplayGromoState(stateGromo);

            MenuItemsState[] templateForMenuItems = ToDefineTemplateBy(stateGromo);
            IO.ToRefreshMainMenuTemplateBy(templateForMenuItems);

            Notice welcome = new Notice(StoreTextsOfNotices.Welcome);
            IO.ToDisplayNewMessage(welcome);
            Notice gromoDisconnected = new Notice(StoreTextsOfNotices.GromoDisconnected);
            IO.ToDisplayNewMessage(gromoDisconnected);
            Notice awaitingDirective = new Notice(StoreTextsOfNotices.AwaitingDirective);
            IO.ToDisplayNewMessage(awaitingDirective);
            IO.MainMenuUserInput.ToTakeCommandForGromo();
        }

        CommandForGromo ToTakeCommand()
        {
            return command;
        }




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
               // TODO: !!!Define validation procedure by Template
            {

            }
            catch (Exception e)
            {  }
            finally
            { }
            
            MenuItemsState[] currentTemplate = IO.ToGetCurrentTemplate();
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
                #region "Exception of StateOfGromo's recognition"
                string message = StoreMessagesOfErrors.MainMenuTemplateDefinition;
                string cause = "Unavailable GromoState for template's definition";
                DateTime time = DateTime.Now;
                throw new MainMenuTemplateDefinitionException(message,cause,time);
                #endregion
            }
            catch (MainMenuTemplateDefinitionException ex)
            { 
                Alert MainMenuTemplateDefinitionError = new Alert(ex.Message);
                IO.ToDisplayNewMessage(MainMenuTemplateDefinitionError);
            }
            finally
            { }
            return definedTemplate;
        }
    }
}
