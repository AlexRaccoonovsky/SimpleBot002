using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.Controller
{
    public class MessageTextStorage
    {
        public int numConnected { get; private set; } = 1;
        public string msgConnected { get; private set; } = "SimpleBot is connected";
    }
}
