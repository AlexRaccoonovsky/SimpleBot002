using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public class Answer:EventArgs
    {
        public readonly string answerParam;
        public Answer(string answr)
        {
            answerParam = answr;
        }
    }
}
