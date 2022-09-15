using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.GromoExceptions.IOExceptions
{
    public class UserInputNotNumberException:ApplicationException
    {
        private string msg = string.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public override string Message
        {
            get { return msg; }
        }
        public UserInputNotNumberException()
        {
            ErrorTimeStamp = DateTime.Now;
            CauseOfError = string.Empty;
        }
        public UserInputNotNumberException(string message, string cause, DateTime time):base(message)
        {
            msg = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public UserInputNotNumberException(GromoExceptionEventArgs arg)
        {
            msg = arg.msgArg;
            CauseOfError = arg.causeArg;
            ErrorTimeStamp = arg.timeExceptionArg;
        }

    }
}
