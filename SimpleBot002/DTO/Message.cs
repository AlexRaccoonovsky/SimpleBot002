using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot002.DTO
{
    public abstract class Message
    {
        public string messageText { get; set; }
        public bool isPresent { get; set; }

        public Message(string msgText="Empty",bool isPresent = false)
        {
            messageText = msgText;
            this.isPresent = isPresent;
        }
        
    
    }


 }