using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2;
using GromoBot2.IO;
using GromoBot2.Controller.GromoCommand;

namespace GromoBot2.Controller.Mode
{
    public class PortfolioDefinitionMode:Modes
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
        void ToInitializeInvironment(GromoBot gromo)
        {
            nameOfMode = "PortfolioDefinitionMode";
            gromoBot = gromo;
            IO = gromo.gromoBotIO;
            stateGromo = gromo.gromoState;
        }
        public override void ToStart(GromoBot gromo)
        {
            try
            {
                IO.ToDisplayGromoState(stateGromo);
                gromo.CurrentMode = new PortfolioDefinitionMode();
                ToInitializeInvironment(gromo);
                IO.ToShowPortfolioDefinitionScreen();

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }


    }
}
