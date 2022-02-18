﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot.Controller;

namespace GromoBot.View
{
    internal class StateParametersArea
    {
        string connectionState;
        string Portfolio;
        string Security;
        public void ToShow(State gromoState)
        {
            ToShowTitle();
            ToShowEndAreaSeparator();
            ToShowStateString(gromoState);
            ToShowEndAreaSeparator();
        }
        void ToShowStateString(State gromoState)
        {
            string stateOfConnection = (gromoState.connectionState).ToString();
            string stateOfPortfolio;
            string stateOfSecurity;
            // Create string stateOfPortfolio for display
            if (gromoState.selectedPortfolio != null)
            { stateOfPortfolio = (gromoState.selectedPortfolio).ToString(); }
            else
            { stateOfPortfolio = "NotSelected!"; }

            // Create string stateOfPortfolio for display
            if (gromoState.selectedSecurity != null)
            { stateOfSecurity = (gromoState.selectedSecurity).ToString(); }
            else
            { stateOfSecurity = "Not Selected!"; }
            // Display State State String
            Console.WriteLine("ConnectionState: {0} | Portfolio: {1} | Security: {2}",stateOfConnection, stateOfPortfolio, stateOfSecurity);
        }
        void ToShowTitle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.stateParametersTitle);
        }
        void ToShowEndAreaSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
        }
    }
}