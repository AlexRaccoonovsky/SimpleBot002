using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBot003.DTO
{
    public class UserInput
    {
        public string strMessage { get; set;}
        public byte numChoice { get; set;}
        public bool isParsed { get; set;} = false;

    }
}
