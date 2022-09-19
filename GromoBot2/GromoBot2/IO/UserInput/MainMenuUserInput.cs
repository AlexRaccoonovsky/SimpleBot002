using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.Controller.GromoCommand.MainMenuModeCommands;
using GromoBot2.Controller.GromoCommand;
using GromoBot2.Controller;
using GromoBot2.IO.GromoMessages;
using GromoBot2.GromoExceptions.IOExceptions;
using GromoBot2.GromoExceptions;

namespace GromoBot2.IO.UserInput
{
    public class MainMenuUserInput
    {
        string inputText;
        int inputNumber;
        CommandForGromo command;
        #region "Definition delegates, events for ExceptionEvents & arguments for ExceptionEvent"
        public delegate void ExceptionEventHandler(object sender, GromoExceptionEventArgs args);
        public event ExceptionEventHandler UserInputIsNotNumberExcep;
        GromoExceptionEventArgs excEventArg;
        #endregion


        public MainMenuUserInput()
        {
            inputText = String.Empty;
            inputNumber = 0;

            excEventArg = new GromoExceptionEventArgs();
        }
        public string InputText
        {
            get { return inputText; }
        }
        public  void ToTakeCommandForGromo()
        {
            // TODO: output value is CommandForGromo
            ToTakeInputString();
            ToTreatInputText();
            ToExtractNumber();


        }
        void ToCheckInput()
        { 
        }
        bool IsValidInput()
        {
            bool isNumber = Int32.TryParse(InputText, out inputNumber);
            return false;
        }
            
        void ToTakeInputString()
        {
            inputText = Console.ReadLine();
        }

        void ToTreatInputText()
        {
            string inputTextTreated = String.Empty;
            string rawText = inputText;

            string inputTextTrimmed = rawText.Trim();
            inputTextTreated = inputTextTrimmed.ToLower();

            inputText = inputTextTreated;
        }
        void ToExtractNumber()
        {
            // TODO: Implement exception structure
            try
            {
                
                bool isNumber = Int32.TryParse(InputText, out inputNumber);
                if (isNumber)
                { return; }
                else
                {
                    string message = StoreTextsOfAlert.UserInputNotNumber;
                    string cause = "MainMenuInput.ToExtractNumber()";
                    DateTime time = DateTime.Now;
                    throw new UserInputNotNumberException(message,cause,time);
                }
            }
            catch (UserInputNotNumberException argOfException)
            {
                string msgEventArgOfError = argOfException.Message;
                string causeEventArgOfError = argOfException.CauseOfError;
                DateTime timeEventArgOfError = argOfException.ErrorTimeStamp;

                GromoExceptionEventArgs excEventArg = new GromoExceptionEventArgs(msgEventArgOfError, causeEventArgOfError, timeEventArgOfError);
                UserInputIsNotNumberExcep?.Invoke(this, excEventArg);
            }
        }
        public CommandForGromo ToConvertIntoCommandFor(GromoBot bot)
        {

            CommandForGromo command;
            command = new CommandConnect(bot);
            return command;
        }

    }
}
