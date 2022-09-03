using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.GromoExceptions.ControllerExceptions
{
    public class MainMenuTemplateDefinitionException :ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public MainMenuTemplateDefinitionException() { }
        public MainMenuTemplateDefinitionException(string message, string cause, DateTime time):base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }


    }
}
