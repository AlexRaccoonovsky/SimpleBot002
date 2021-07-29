using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.Model
{
    public class ConnectorArgs:EventArgs
    {
        public readonly string nameEvent;
        public ConnectorArgs(string name)
        {
            nameEvent = name;
        }
    }
}
