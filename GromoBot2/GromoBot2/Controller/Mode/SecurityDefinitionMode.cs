using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.Controller;
using GromoBot2.IO;
using GromoBot2.Controller.GromoCommand;


namespace GromoBot2.Controller.Mode
{
    public class SecurityDefinitionMode:Modes
    {
        string nameOfMode;
        GromoBot gromoBot;
        GromoBotIO IO;
        StateOfGromo stateGromo;
        CommandForGromo command;
        public override string Name
        {
            get { return nameOfMode; } 
        }
        void ToInitializeEnvironment(GromoBot gromo)
        {
            nameOfMode = "SecurityDefinitionMode";
            gromoBot = gromo;
            IO = gromo.gromoBotIO;
            stateGromo = gromo.gromoState;
            command = new CommandEmpty(gromo);
        }
        public override void ToStart(GromoBot gromo)
        {

            
        }

    }
}
