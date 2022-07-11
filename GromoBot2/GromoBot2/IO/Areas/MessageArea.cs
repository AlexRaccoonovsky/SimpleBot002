using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.GromoMessages;

namespace GromoBot2.IO.Areas
{
    public class MessageArea:Area
    {
        string titleName = "Message Area";
        string areaSeparator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        int rowsNumOfArea = 4;
        Queue<GromoMessage> bufferOfMessages;
        public MessageArea()
        { 
            ToInitializeBufferOfMessage();
        }
        public override string areaTitleName
        {
            get => titleName;
        }
        public override string areaSeparatorType
        {
            get => areaSeparator;
        }
        public int rowsNumberOfArea 
        { 
            get
            {
                return rowsNumOfArea;
            }
            set
            {
                rowsNumOfArea = value;
            }
        }
        public override void ToDisplayTitle()
        {
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.WriteLine(titleName);
        }
        public override void ToDisplaySeparator()
        {
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparatorType);
        }
        void ToInitializeBufferOfMessage()
        {
            bufferOfMessages = new Queue<GromoMessage>(rowsNumberOfArea);
            Notice emptyNotice = new Notice(" ");
            for (int i = 0; i < rowsNumberOfArea; i++)
            {
                bufferOfMessages.Enqueue(emptyNotice);
            }
        }
        public void AddUpToBuffer(GromoMessage msg)
        {
            bufferOfMessages.Enqueue(msg);
            bufferOfMessages.Dequeue();
        }
        public void ToShowBuffer()
        {
            //for (int i = rowsNumberOfArea;i>0;i--)
            foreach (GromoMessage message in bufferOfMessages)
            {
                Console.WriteLine(message.textMessage);
            }
        }
    }
}
