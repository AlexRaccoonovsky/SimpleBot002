using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Messages;
using StockSharp.BusinessEntities;
using GromoBot.View;

namespace GromoBot.Controller
{
    public class Gromo
    {
        public ModesOfGromo currentMode { get; private set; } 
        public StateOfGromo currentState { get; private set; }
        GromoBotIO gromoIO;
        UserInput inputOfUser;
        public Gromo()
        { 
            gromoIO = new GromoBotIO();
            currentState = new StateOfGromo();
            currentMode = ModesOfGromo.MainMenuMode;
            inputOfUser = new UserInput();
        }

        public void ToStartMainMenuMode()
        {
            gromoIO.ToStartIO(currentState);
            inputOfUser.ToFetch();
            Notice notice = new Notice();
            notice.messageNotice = inputOfUser.userInput;
            gromoIO.ToShowNotice(notice);
        }

    }
}
