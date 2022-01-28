using System;

using SBot003.DTO;

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
        public UserInput ToTakeUserInput()
        {
            // Create UserChoice object
            UserInput userInput = new UserInput();
            // Take user answer
            userInput.strMessage = Console.ReadLine();
            return userInput;
        }
        public void ShowNotice(Notice obj)
        {
            // Change Console color for Notice-message
            Console.ForegroundColor = ConsoleColor.Green;
            // Print DateTime prefix
            InsertDateTimePrefix();
            // Print message of Notice
            Console.WriteLine(obj.messageNotice);
        }
        public void ShowAlert(Alert obj)
        {
            // Change Console color for Notice-message
            Console.ForegroundColor = ConsoleColor.Red;
            // Print DateTime prefix
            InsertDateTimePrefix();
            // Print message of Notice
            Console.WriteLine(obj.messageAlert);
        }

        void InsertDateTimePrefix()
        {
            Console.Write("[{0}]   |   ", DateTime.Now);
        }

    }
}
