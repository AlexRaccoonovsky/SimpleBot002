﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBot003.Controller
{
    public static class TxtMessageStorage
    {
        public static string emptyMessage { get; private set;  } = "EmptyMessage";
        public static string messageTryAgain { get; private set; } = "Input is incorrect. Please try again!";
    }
}