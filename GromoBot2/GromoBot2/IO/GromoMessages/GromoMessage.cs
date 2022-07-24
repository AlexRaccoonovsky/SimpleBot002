using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.GromoMessages
{
    public abstract class GromoMessage
    {
        public byte limitOfMessageSymbols = 50;
        public const ConsoleColor noticeColor = ConsoleColor.Green;
        public const ConsoleColor queryColor = ConsoleColor.Yellow;
        public const ConsoleColor alertColor = ConsoleColor.Red;
        public abstract string textMessage { get; set; }
        //public abstract GromoMessage ToCreate(string txtMessage);

    }
}
