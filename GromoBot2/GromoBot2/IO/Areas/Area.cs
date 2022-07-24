using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.IO.Areas
{
    public abstract class Area
    {
        // Indents Of Area's Parts
        public const byte indentOfAreaTitle = 15;
        public const byte indentOfAreaContent = 5;
        public const byte indentOfAreaSeparator = indentOfAreaContent;
        // Colors Area's Objects
        public const ConsoleColor titleAreaColorFront = ConsoleColor.DarkMagenta;
        public const ConsoleColor titleAreaColorBack = ConsoleColor.Cyan;
        public const ConsoleColor separatorAreaColorFront = titleAreaColorBack;
        public const ConsoleColor separatorAreaColorBack = ConsoleColor.Black;
        // Parameters Of Area's members
        public abstract string areaTitleName { get; }
        public abstract string areaSeparatorType { get; }
        public abstract void ToDisplayTitle();
        public abstract void ToDisplaySeparator();
     
        
    }
}
