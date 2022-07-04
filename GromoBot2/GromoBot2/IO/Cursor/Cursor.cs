using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Cursor;

namespace GromoBot2.IO.Cursor
{
    internal class Cursor
    {
        CursorPosition currentPosition;
        public Cursor()
        {
            currentPosition = new CursorPosition(); 
        }
    }
}
