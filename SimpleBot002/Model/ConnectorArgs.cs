using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.BusinessEntities;


namespace SimpleBot002.Model
{
    public class ConnectorArgs:EventArgs
    {
        public readonly string nameEvent;
        public readonly Security selectedSecurity;
        public ConnectorArgs(string nameEv)
        {
            nameEvent = nameEv;
        }
        public ConnectorArgs(string nameEv, Security selSec)
        {
            nameEvent = nameEv;
            selectedSecurity = selSec;
        }
    }
}
