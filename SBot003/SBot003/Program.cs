using System;
using SBot003.Controller;

namespace SBot003
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.StartToDispatch();
        }
    }
}
