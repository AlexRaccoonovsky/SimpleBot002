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
        static Notice CreateNotice(string msg)
        {
            Notice notice = new Notice(msg);
            return notice;
        }

    }
}
