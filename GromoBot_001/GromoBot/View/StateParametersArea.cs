using System;
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
        public void ToShow(Cursor cursor, CursorPosition cursorPosition, State gromoState)
        {
            ToShowTitle(cursor,cursorPosition);
            ToShowEndAreaSeparator(cursor, cursorPosition);
            ToShowStateString(cursor, cursorPosition,gromoState);
            ToShowEndAreaSeparator(cursor, cursorPosition);
        }
        void ToShowStateString(Cursor cursor, CursorPosition cursorPosition, State gromoState)
        {
            string stateOfConnection = (gromoState.connectionState).ToString();
            string stateOfPortfolio;
            string stateOfSecurity;
            cursor.ToSetPosition(cursorPosition.lastPosition);
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
            // Set field lastRowOfMessage of CursorPosition to current value
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
        void ToShowTitle(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.stateParametersTitle);
            // Set field lastRowOfMessage of CursorPosition to current value
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
        void ToShowEndAreaSeparator(Cursor cursor, CursorPosition cursorPosition)
        {
            cursor.ToSetPosition(cursorPosition.lastPosition);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
            // Set field lastRowOfMessage of CursorPosition to current value
            cursorPosition.lastPosition.numOfRow = Console.CursorLeft;
            cursorPosition.lastPosition.numOfColumn = Console.CursorTop;
        }
    }
}
