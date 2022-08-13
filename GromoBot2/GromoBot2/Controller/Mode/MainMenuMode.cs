﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;
using GromoBot2.IO.Areas;
using GromoBot2.Controller.GromoCommand;


namespace GromoBot2.Controller.Mode
{
    public class MainMenuMode:Mode
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
        void ToInitializeEnvironment(GromoBot bot)
        {
            string nameOfMode = "MainMenuMode";
            this.gromoBot = bot;
            this.nameOfMode = nameOfMode;
            this.IO = bot.gromoBotIO;
            this.stateGromo = bot.gromoState;
        }
        public void ToStartFirstTime(GromoBot gromo)
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
            if (numOfInput == 2)
            { }
        }
        public override void ToStart(GromoBot gromo)
        { }
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
