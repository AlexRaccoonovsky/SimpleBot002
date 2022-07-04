using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.Controller.GromoMessage
{
    public abstract class GromoMessage
    {
        public string textMessage { get; set; }
        public abstract GromoMessage ToCreate(string txtMessage);

    }
}
