using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.GromoExceptions.IOExceptions
{
    public class DifferentSizeException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public DifferentSizeException()
        { 
            ErrorTimeStamp = DateTime.Now;
            CauseOfError = string.Empty;
        }
        public DifferentSizeException(string message,string cause, DateTime time):base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }
}
