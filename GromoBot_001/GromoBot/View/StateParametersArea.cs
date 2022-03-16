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
        public void ToShow(Cursor cursor, StateOfGromo gromoState)
        {
            ToShowTitle(cursor);
            ToShowEndAreaSeparator(cursor);
            ToShowStateString(cursor, gromoState);
            ToShowEndAreaSeparator(cursor);
        }
        void ToShowStateString(Cursor cursor, StateOfGromo gromoState)
        {
            string stateOfConnection = (gromoState.connectionState).ToString();
            string stateOfPortfolio = "TestPortfolio";
            string stateOfSecurity = "TestSecurity";
            // Define value of string stateOfPortfolio
              if (gromoState.selectedPortfolio != null)
                 { stateOfPortfolio = (gromoState.selectedPortfolio).ToString(); }
              else
                 { stateOfPortfolio = "NotSelected!"; }
            // Define value of string stateOfSecurity
              if (gromoState.selectedSecurity != null)
                 { stateOfSecurity = (gromoState.selectedSecurity).ToString(); }
              else
                 { stateOfSecurity = "Not Selected!"; }
            // Set cursor for the string with state of parameters
            cursor.ToSetPosition(cursor.positionStore.leftIndentOfBody, cursor.positionStore.lastRow);
            // Display State State String
            Console.WriteLine("ConnectionState: {0} | Portfolio: {1} | Security: {2}",stateOfConnection, stateOfPortfolio, stateOfSecurity);
            // Save last position of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }
        void ToShowTitle(Cursor cursor)
        {
            // Set cursor for title
            cursor.ToSetPosition(cursor.positionStore.leftIndentOfTitle, cursor.positionStore.lastRow);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SignsOfMenuItemsStore.stateParametersTitle);
            // Save last position of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }
        void ToShowEndAreaSeparator(Cursor cursor)
        {
            // Set position of cursor in a last position
            cursor.ToSetPosition(0, cursor.ToGetLastRowFromStore());
            // Choose a color for separator
            Console.ForegroundColor = ConsoleColor.DarkGray;
            // Take a separator symbols from store
            Console.WriteLine(SignsOfMenuItemsStore.endOfAreaSeparator);
            // Save last position of cursor
            cursor.positionStore.ToSaveLastRow(Console.CursorTop);
        }
    }
}
