using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBot003.ServiceStorage
{
    public static class TxtMessageStorage
    {
        public static string emptyMessage { get; private set;  } = "EmptyMessage";
        public static string incorrectInput { get; private set; } = "Input is incorrect. Please try again!";
        public static string signNoticeConnectionState { get; private set; } = "State Of Connection:";
        public static string titleForCurrentParameters { get; private set; } = "Current State Of GromoBot";
    }
}
