using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Screens
{
    public abstract class Screen
    {
        public const byte indentOfScreenTitle = 50;
        public const byte indentOfScreenString = 5;
        public const ConsoleColor titleScreenColorFront = ConsoleColor.Yellow;
        public const ConsoleColor titleScreenColorBack = ConsoleColor.DarkGreen;
        public abstract string screenTitleName { get; }
        public abstract CursorPositionStore cursorPositionStore { get; }
        public abstract Cursor cursor { get; }
        public abstract void ToDisplayTitle();
        public abstract void ToShow();
        public abstract void ToHide();
        public abstract void ToRefreshStateArea();
        // TODO: Dispose objects & CLS - operator info
        //public abstract void ToClose();
        
    }
}
