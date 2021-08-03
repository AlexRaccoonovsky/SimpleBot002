using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public class Alert:Message
    {
        public string messageAlert { get; set; }
        public bool isPresent { get; set; }

        public Alert(string txtAlert = "EmptyAlert")
        {
            messageAlert = txtAlert;
            isPresent = false;
        }

        public Alert(string txtAlert = "EmptyAlert", bool isPresent = false)
        {
            messageAlert = txtAlert;
            this.isPresent = isPresent;
        }
        
    }
}
