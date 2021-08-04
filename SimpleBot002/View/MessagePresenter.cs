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
            Console.WriteLine(obj.messageAlert);
        }

        // Check field .Message
        public void ShowException(Exception obj)
        {
            Console.WriteLine(obj.Message);
        }

        public void ShowNotice(Notice obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(obj.messageNotice);
        }

        public Answer ShowQuery(Query obj)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(obj.messageText);
            string ans = Console.ReadLine();
            Answer _answer = new Answer(ans);
            return _answer;
        }
    }
}
