using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.DTO;

namespace SimpleBot002.View
{
    public interface IView
    {
        public void ShowNotice(Notice obj);
        public void ShowAlert(Alert obj);

        public void ShowException(Exception obj);
        public void ShowQuery(Query obj);
    }
}
