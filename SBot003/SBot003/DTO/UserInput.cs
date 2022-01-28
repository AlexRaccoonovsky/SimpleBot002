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
        // Rendering property strMessage which using by Dispatcher
        public byte? numChoice { get; set; } = null;
        // Property indicating result of parsing
        public bool isParsed { get; set;} = false;
        // Property indicatin result of validation check
        public bool isValidRangeOfMenu { get; set;} = false;
    }
}
