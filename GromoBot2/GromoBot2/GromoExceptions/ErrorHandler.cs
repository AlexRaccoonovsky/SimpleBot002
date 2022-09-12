using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO;
using GromoBot2.IO.GromoMessages;

namespace GromoBot2.GromoExceptions
{
    internal class ErrorHandler
    {
        GromoBotIO io;
        public ErrorHandler(GromoBotIO IO)
        {
            io = IO;
        }
        public void ToShowAlert (Exception exception)
        {
            Alert alert = new Alert(exception.Message);
            io.ToDisplayNewMessage(alert);
        }

    }
}
