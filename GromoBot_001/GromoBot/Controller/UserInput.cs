using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.Controller
{
    public class UserInput
    {
        public string userInput { get; private set; }
        public int userInputNum { get; private set; }


        public void ToFetch()
        { 
            userInput = Console.ReadLine();
            return;
        }
        
    }
}
