using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBot003.DTO
{
    public class Query : Message
    {
        public string messageText { get; set; }
        public Answer answer { get; set; }
    }
}
