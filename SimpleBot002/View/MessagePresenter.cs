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
            Console.WriteLine(obj.messageText);
        }

        // Check field .Message
        public void ShowException(Exception obj)
        {
            Console.WriteLine(obj.Message);
        }

        public void ShowNotice(Notice obj)
        {
            Console.WriteLine(obj.messageText);
        }

        // !! Need to define output class Answer instead void
        public void ShowQuery(Query obj)
        {
            Console.WriteLine("!!!REalize answer");
        }
    }
}
