using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public class Notice:Message
    {
        public string messageNotice { get; set; }
        public bool isPresent { get; set; }
        public Notice(string txtNotice = "EmptyNotice")
        {
            messageNotice = txtNotice;
            isPresent = false;
        }
        public Notice(string txtNotice = "EmptyNotice", bool isPresent = false)
        {
            messageNotice = txtNotice;
            this.isPresent = isPresent;
        }
        

    }
}
