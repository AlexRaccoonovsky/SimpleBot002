using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Areas
{
    public abstract class Area
    {
        // Indents Of Area's Parts
        public const int indentOfAreaTitle = 15;
        public const int indentOfAreaContent = 5;
        public const int indentOfMessageAreaContent = 7;
        public const int indentOfAreaSeparator = indentOfAreaContent;
        // Colors Area's Objects
        public const ConsoleColor titleAreaColorFront = ConsoleColor.DarkMagenta;
        public const ConsoleColor titleAreaColorBack = ConsoleColor.Cyan;
        public const ConsoleColor separatorAreaColorFront = titleAreaColorBack;
        public const ConsoleColor separatorAreaColorBack = ConsoleColor.Black;
        // Parameters Of Area's members
        public abstract Cursor areaCursor {get;set;}
        public abstract CursorPositionStore areaCursorPositionStore { get;set;}
        public abstract string areaTitleName { get; }
        public abstract string areaSeparatorType { get; }
        public abstract void ToDisplayTitle();
        public abstract void ToDisplaySeparator();
     
        
    }
}
