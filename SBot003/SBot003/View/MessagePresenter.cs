using System;

using SBot003.DTO;

namespace SBot003.View
{
    class MessagePresenter
    {
        public void ToShowMainMenu()
        {
            Console.WriteLine("********MainMenu********");
            Console.WriteLine("1. Connect");
            Console.WriteLine("2. Set Portfolio");
            Console.WriteLine("3. Set Security");
            Console.WriteLine("4. ObserverMode");
            Console.WriteLine("5. TraderMode");
            Console.WriteLine("6. Disconnect");
            Console.WriteLine("7. Exit");
            Console.WriteLine("---------------");
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

        internal void InsertDateTimePrefix()
        {
            Console.Write("[{0}]   |   ", DateTime.Now);
        }

    }
}
