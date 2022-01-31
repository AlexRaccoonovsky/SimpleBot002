using System;

using SBot003.DTO;
using SBot003.Controller;

namespace SBot003.View
{
    class MessagePresenter
    {
        public void ToShowMenu(string[] menuStrings)
        {
            foreach (string str in menuStrings)
            { 
                Console.WriteLine(str);
            }

        }
        public void ToShowStateNotice(StateNotice obj)
        {
            // Change Console color for stateNotice message
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------");
            Console.WriteLine(obj.messageText);
            Console.WriteLine("------------");
            for (int i = 0; i < Dispatcher.numOfGromoBotParameters; i++)
            {
                Console.Write(obj.txtStateSigns[i]);
                Console.Write(obj.valuesOfStateParam[i]+"\r\n");
            }
            Console.WriteLine("------------");
        }
        public UserInput ToTakeUserInput()
        {
            // Create UserChoice object
            UserInput userInput = new UserInput();
            // Take user answer
            userInput.strMessage = Console.ReadLine();
            return userInput;
        }
        public void ToShowNotice(Notice obj)
        {
            // Change Console color for Notice-message
            Console.ForegroundColor = ConsoleColor.Green;
            // Print DateTime prefix
            InsertDateTimePrefix();
            // Print message of Notice
            Console.WriteLine(obj.messageNotice);
        }
        public void ToShowAlert(Alert obj)
        {
            // Change Console color for Notice-message
            Console.ForegroundColor = ConsoleColor.Red;
            // Print DateTime prefix
            InsertDateTimePrefix();
            // Print message of Notice
            Console.WriteLine(obj.messageAlert);
        }
        public void ToShowStateOfGromoBot()
        {
            Console.WriteLine("Cu");
        }

        void InsertDateTimePrefix()
        {
            Console.Write("[{0}]   |   ", DateTime.Now);
        }

    }
}
