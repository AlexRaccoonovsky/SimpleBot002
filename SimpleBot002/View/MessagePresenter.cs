using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.Model;
using SimpleBot002.DTO;
using SimpleBot002.Controller;
using SimpleBot002.View;


namespace SimpleBot002.View
{
    class MessagePresenter : IView
    {
        public void ShowAlert(Alert obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            InsertDateTimeNow();
            Console.WriteLine(obj.messageAlert);
        }

        // Check field .Message
        public void ShowException(Exception obj)
        {
            InsertDateTimeNow();
            Console.WriteLine(obj.Message);
        }

        public void ShowNotice(Notice obj)
        {
            // Change Console color for Notice-message
            Console.ForegroundColor = ConsoleColor.Green;
            // Insert DateTime prefix
            InsertDateTimeNow();
            Console.WriteLine(obj.messageNotice);
        }

        public Answer ShowQuery(Query obj)
        {
            // Change Console color for Query-message
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            // Insert DateTime prefix
            InsertDateTimeNow();
            // Ask a question
            Console.Write(obj.messageText);
            // Processing answer
            string ans = Console.ReadLine();
            // Trimming & lowerCase by AnswerHandler
            string ansHndlr = AnswerHandler(ans);
            Answer _answer = new Answer(ansHndlr);
            return _answer;
        }
        void InsertDateTimeNow()
        {
            Console.Write("[{0}] ", DateTime.Now);
        }

        string AnswerHandler(string str)
        {
            // Initialize handling string - string after trimming & in 
            string handlstring;
            // Handling
            handlstring = (str.Trim()).ToLower();
            return handlstring;
        }


    }
}
