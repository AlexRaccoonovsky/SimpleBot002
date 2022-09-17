using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.GromoExceptions
{
    public class GromoExceptionEventArgs:EventArgs
    {
        public readonly string msgArg;
        public readonly string causeArg;
        public readonly DateTime timeExceptionArg;
        public GromoExceptionEventArgs()
        {
            msgArg = String.Empty;
            causeArg = String.Empty;
            timeExceptionArg = DateTime.MinValue;
        }
        public GromoExceptionEventArgs(string message, string cause, DateTime time)
        {
            this.msgArg = message;
            this.causeArg = cause;
            this.timeExceptionArg = time;
        }
    }
}
