using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.BusinessEntities;

namespace SimpleBot002.Model
{
    public class PortfolioArgs:EventArgs
    {
        public readonly string nameOfEvent;
        public readonly Portfolio selectPortfolio;
        public PortfolioArgs(string nameEvent, Portfolio selectedPortfolio)
        {
            nameOfEvent = nameEvent;
            selectPortfolio = selectedPortfolio;
        }
    }
}
