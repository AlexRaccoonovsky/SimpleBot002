using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.BusinessEntities;

namespace SimpleBot002.Model
{
    public class SecurityArgs:EventArgs
    {
        public readonly string nameOfEvent;
        public readonly Security selectedSecurity;
        public SecurityArgs(string nameEvent, Security selSec)
        {
            nameOfEvent = nameEvent;
            selectedSecurity = selSec;
        }

    }
}
