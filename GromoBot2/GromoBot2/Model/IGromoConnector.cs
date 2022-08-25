using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot2.Model
{
    public interface IGromoConnector
    {
        GromoConnector GromoConnector { get; }
        void ToSubscribeOnEvents();
        
    }
}
