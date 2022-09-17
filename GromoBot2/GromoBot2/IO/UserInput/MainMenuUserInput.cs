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
        ErrorHandler errorHandler;
        CommandForGromo command;
        #region "Definition delegates & event for event_NewException"
        public delegate void ExceptionEventHandler(object sender, GromoExceptionEventArgs args);
        public event ExceptionEventHandler UserInputIsNotNumberExcep;
        #endregion
        GromoExceptionEventArgs excEventArg;
        //GromoExceptionEventArgs gromoExceptionEventArgsEmpty = new GromoExceptionEventArgs();


        public MainMenuUserInput()
        {
            inputText = String.Empty;
            inputNumber = 0;

            //errorHandler = new ErrorHandler(IO);
            excEventArg = new GromoExceptionEventArgs();

            //command = new CommandEmpty();
 
        }
        public string InputText
        {
            get { return inputText; }
           // set { inputText = value; }
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
            catch (UserInputNotNumberException argumentOfException)
            {
                string msgEventArgOfError = argumentOfException.Message;
                string causeEventArgOfError = argumentOfException.CauseOfError;
                DateTime timeEventArgOfError = argumentOfException.ErrorTimeStamp;

                GromoExceptionEventArgs excEventArg = new GromoExceptionEventArgs(msgEventArgOfError, causeEventArgOfError, timeEventArgOfError);
                UserInputIsNotNumberExcep?.Invoke(this, excEventArg);
            }
            finally
            {
                
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
