﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.Controller
{
    public class TxtMessageStorage
    {
        public string noticeConnected { get; private set; } = "SimpleBot is connected to Quik";
        public string noticeWelcome { get; private set; } = "Hi! My name is SimpleBot002. Shortly - Bot.";
        public string queryConnect { get; private set; } = "Do you want connect to Quik? (y/n):";
        public string noticeCurrentState { get; private set; } = "Current state of Bot: ";
        public string noticeSecuritySelected { get; private set; } = "Id of selected security: ";
        public string noticePortfolioSelected { get; private set; } = "Code of selected portfolio: ";
        public string noticeGoodBuy { get; private set; } = "Good buy, friend!";

    }

}
