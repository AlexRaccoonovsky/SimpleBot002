using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.DTO;

namespace SimpleBot002.Controller
{
    static class MessageMaker
    {
        static Notice CreateNotice(string txtNotice)
        {
            Notice _notice = new Notice(txtNotice);
            return _notice;
        }
        static Alert CreateAlert(string txtAlert)
        {
            Alert _alert = new Alert(txtAlert);
            return _alert;
        }

    }
}
