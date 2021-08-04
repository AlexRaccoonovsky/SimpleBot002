using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBot002.DTO;

namespace SimpleBot002.View
{
    public class ViewArgs:EventArgs
    {
        public readonly string nameEvent;
        public readonly Answer answer;
        public ViewArgs(string nameEv, Answer answ)
        {
            nameEvent = nameEv;
            answer = answ;
        }

    }
}
