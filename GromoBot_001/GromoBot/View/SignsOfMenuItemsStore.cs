using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    public static class SignsOfMenuItemsStore
    {
        public static string mainMenuTitle { get; set; } = "* * * * Main Menu * * * *";
        public static string[] mainMenuItems = new string[]
          {   "1. Connect",
              "2. Set Portfolio",
              "3. Set Security",
              "4. ObserverMode",
              "5. TraderMode",
              "6. Disconnect",
              "7. Exit",
          };
        public static string endOfAreaSeparator { get; set; } =  "---------------";
        public static string stateParametersTitle { get; set; } = "* * * *State Parameters Of GromoBot * * * *";
        public static string userInputTitle { get; set; } = "+ + + + User Input + + + +";
        public static string messageAreaTitle { get; set; } = "# # # # Messages Of GromoBot # # # #";


    }
}
