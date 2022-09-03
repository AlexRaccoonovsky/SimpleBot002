using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.Controller.GromoCommand.MainMenuModeCommands;
using GromoBot2.Controller.GromoCommand;
using GromoBot2.Controller;

namespace GromoBot2.IO.UserInput
{
    public class MainMenuUserInput
    {
        string inputText = String.Empty;
        public string InputText
        {
            get { return inputText; }
            set { inputText = value; }
        }
        public void ToTake()
        {
            inputText = Console.ReadLine();
        }

        void ToTreatInputText(string rawText)
        {
            string inputTextTreated = String.Empty;
            string inputTextTrimmed = rawText.Trim();
            inputTextTreated = inputTextTrimmed.ToLower();
            inputText = inputTextTreated;
        }
        public int ToExtractNumber()
        {
            int number = 0;
            number = Int32.Parse(inputText);
            return number;
        }
        public CommandForGromo ToConvertIntoCommandFor(GromoBot bot)
        {
            CommandForGromo command;
            command = new CommandConnect(bot);
            return command;
        }

    }
}
