using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.Controller
{
    class ModelListener
    {
        public delegate void ModelEventHandler();
        public event ModelEventHandler Connected;

    }
}
