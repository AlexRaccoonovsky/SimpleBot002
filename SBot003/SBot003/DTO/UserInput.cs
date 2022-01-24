using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBot003.DTO
{
    public class UserInput
    {
        // Property contain input of User
        public string strMessage { get; set;}
        // Handling input of User which using by Dispatcher
        public byte numChoice { get; set;}
        // 
        public bool isParsed { get; set;} = false;
    }
}
