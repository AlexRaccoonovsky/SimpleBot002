using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.DTO;

namespace SBot003.View
{
    class MessagePresenter
    {
        public void ShowMainMenu()
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
        //public void Show
        public UserInput TakeUserInput()
        {
            // Create UserChoice object
            UserInput userChoice = new UserInput();
            // Take user answer
            userChoice.strMessage = Console.ReadLine();
            return userChoice;
        }
    }
}
