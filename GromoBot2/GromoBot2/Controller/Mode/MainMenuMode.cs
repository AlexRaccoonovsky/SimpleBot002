using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;
using GromoBot2.IO.Areas;


namespace GromoBot2.Controller.Mode
{
    public class MainMenuMode:Mode
    {
        string nameOfMode;
        GromoBotIO IO;
        StateOfGromo stateGromo;
        
        public override string Name 
        {
            get { return nameOfMode; }

        }
        void ToInitializeEnvironment(GromoBot bot)
        {
            string nameOfMode = "MainMenuMode";
            this.nameOfMode = nameOfMode;
            this.IO = bot.gromoBotIO;
            this.stateGromo = bot.gromoState;
        }
        public override void ToStart(GromoBot gromo)
        { 
            ToInitializeEnvironment(gromo);
            IO.ToShowMainMenuScreen();
            IO.ToDisplayGromoState(stateGromo);
            Notice Welcome = new Notice(StoreTextsOfMessages.welcome);
            IO.ToDisplayNewMessage(Welcome);
            
            int numOfInput = this.ToTakeMainMenuInput();

            if (IsValidInput(numOfInput))
            {
                Notice validInput = new Notice("input is Valid");
                IO.ToDisplayNewMessage(validInput);
            }
            else
            {
                Alert invalidInput = new Alert("Invalid Input!!!");
                IO.ToDisplayNewMessage(invalidInput);
            }
        }
        int ToTakeMainMenuInput()
        {
            int numOfUserInput = 0;
            try
            {
                UserInput userInput = new UserInput();
                userInput.ToTake();
                numOfUserInput = Int32.Parse(userInput.inputText);
            }
            catch (Exception ex)
            {
                Alert errorOfInput = new Alert(StoreTextsOfMessages.errorOfInputMainMenu);
                IO.ToDisplayNewMessage(errorOfInput);
            }
            finally 
            { 
            }
            return numOfUserInput;
        }
        bool IsValidInput(int input)
        {
            MenuItemsState[] currentTemplate = IO.ToGetTemplateForMainMenuScreen();
            if (currentTemplate[input-1] == MenuItemsState.Enabled )
               return true;
            else
               return false;
        }
    }
}
