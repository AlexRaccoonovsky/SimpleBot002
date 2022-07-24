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
        byte rowsNumOfArea = 4;
        Queue<GromoMessage> bufferOfMessages;
        GromoMessage[] arrayForDisplay;
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
        public byte rowsNumberOfArea 
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
            arrayForDisplay = new GromoMessage[rowsNumberOfArea];
            Notice emptyNotice = new Notice(" ");
            for (int i = 0; i < rowsNumberOfArea; i++)
            {
                bufferOfMessages.Enqueue(emptyNotice);
            }
            arrayForDisplay=bufferOfMessages.ToArray();
        }
        public void ToAddUpBuffer(GromoMessage msg)
        {
            bufferOfMessages.Enqueue(msg);
            bufferOfMessages.Dequeue();
            arrayForDisplay = bufferOfMessages.ToArray();
            arrayForDisplay.Reverse();
        }
        public void ToDisplayBuffer()
        {
            for (int i = rowsNumberOfArea - 1; i >= 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                if (arrayForDisplay[i] is Alert)
                {
                    Console.ForegroundColor = GromoMessage.alertColor;
                    Console.WriteLine(arrayForDisplay[i].textMessage);
                }
                if (arrayForDisplay[i] is Notice)
                {
                    Console.ForegroundColor = GromoMessage.noticeColor;
                    Console.WriteLine(arrayForDisplay[i].textMessage);
                }
                if (arrayForDisplay[i] is Query)
                {
                    Console.ForegroundColor = GromoMessage.queryColor;
                    Console.WriteLine(arrayForDisplay[i].textMessage);
                }

            }
        }
        public void ToCleanUp()
        {
            for (int i = 0; i < rowsNumberOfArea; i++)
            {
                Console.Write(new String(' ', Console.BufferWidth));
            }

        }
    }
}
