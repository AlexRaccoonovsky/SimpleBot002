using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;


namespace GromoBot2.Controller.Mode
{
    public class MainMenuMode:Mode
    {
        GromoBotIO forModeIO;
        StateOfGromo stateGromo;
        string nameOfMode;
        public override string Name 
        {
            get { return nameOfMode; }
            set { nameOfMode = value; }
        }
        public override GromoBotIO gromoBotIO
        {
            get { return forModeIO; }
            set { forModeIO = value; }
        }
        public override StateOfGromo stateOfGromo
        {
            get { return stateGromo; }
            set { stateGromo = value; }
        }
        public override void ToStart(ref GromoBotIO gromoIO,ref StateOfGromo currentGromoState)
        { 
            this.ToInitializeEnvironment(gromoIO,currentGromoState);
            gromoIO.ToShowMainMenuScreen();
            // Test duplicate in a MessageArea
            UserInput userInput = new UserInput();
            userInput.inputText = Console.ReadLine();
            Notice doubleToMessageArea = new Notice(userInput.inputText);
            gromoIO.ToDisplayNewMessage(doubleToMessageArea);

        }
         public override void ToInitializeEnvironment(GromoBotIO gromoIO,StateOfGromo currentGromoState)
         {
            string nameOfMode = "MainMenuMode";
            this.nameOfMode = nameOfMode;
            this.gromoBotIO = gromoIO;
            this.stateGromo = currentGromoState;
         }
    }
}
