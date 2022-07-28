using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.Controller.Mode;
using GromoBot2.IO.GromoMessages;

namespace GromoBot2.Controller
{
    public class Gromo
    {
        GromoBotIO gromoIO;
        StateOfGromo currentState;
        public Gromo()
        { 
            gromoIO = new GromoBotIO();
            currentState = new StateOfGromo();
            currentState.GromoStateChanged += ToNotifyUser;
        }
        public void ToStartUp()
        {
            MainMenuMode mainMenuMode = new MainMenuMode();
            mainMenuMode.ToStart(ref gromoIO, ref currentState);

        }
        // Test method for MessageArea work
        void ToShowMessage()
        {
            string text1 = "Hello!";
            string text2 = "World";
            string text3 = "from Gromobot)";
            string text4 = "1";
            string text5 = "2";
            Notice notice1 = new Notice(text1);
            Notice notice2 = new Notice(text2);
            Notice notice3 = new Notice(text3);
            Notice notice4 = new Notice(text4);
            Notice notice5 = new Notice(text5);
            Query query6 = new Query(text5);
            gromoIO.ToDisplayNewMessage(notice1);
            gromoIO.ToDisplayNewMessage(notice2);
            gromoIO.ToDisplayNewMessage(notice3);
            gromoIO.ToDisplayNewMessage(notice4);
            gromoIO.ToDisplayNewMessage(notice5);
            gromoIO.ToDisplayNewMessage(query6);
            // Need to realize
            //notice1.AddToBuffer();
            //notice1.ToDisplay()

        }
        // Test method for GromoStateChanged
        void ToNotifyUser(StateOfGromo state, GromoStateChangedEventArgs arg)
        { 
            gromoIO.ToDisplayNewMessage(arg.gromoMessage);

        }
        // Test changing of GromoState
        void ToChangeGromoState()
        {
            Thread.Sleep(1000);
            currentState.ToSetConnectionState(StockSharp.Messages.ConnectionStates.Connected);
        }

    }
}
