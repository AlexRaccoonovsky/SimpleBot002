using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.GromoMessages;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Areas
{
    public class MessageArea:Area
    {
        string titleName = "Message Area";
        string areaSeparator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        byte rowsNumOfArea = 9;
        Cursor messageAreaCursor;
        CursorPositionStore messageAreaCursorPositionStore;
        Queue<GromoMessage> bufferOfMessages;
        GromoMessage[] arrayForDisplay;
        public MessageArea()
        { 
            messageAreaCursor = new Cursor();
            messageAreaCursorPositionStore = new CursorPositionStore();
            ToInitializeBufferOfMessage();
        }
        public override Cursor areaCursor
        {
            get { return messageAreaCursor; }
            set { messageAreaCursor = value; }
        }
        public override CursorPositionStore areaCursorPositionStore {
            get { return messageAreaCursorPositionStore; }
            set { messageAreaCursorPositionStore = value; } }
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
            int lastRow = messageAreaCursor.ToGetLastRowNumber();
            messageAreaCursor.ToSetInPosition(Area.indentOfAreaTitle, lastRow);
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.WriteLine(titleName);
            messageAreaCursor.ToSavePosition();
        }
        public override void ToDisplaySeparator()
        {
            int lastRow = messageAreaCursor.ToGetLastRowNumber();
            messageAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator,lastRow);
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparatorType);
            messageAreaCursor.ToSavePosition();
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
            messageAreaCursor.ToSetInPosition(messageAreaCursorPositionStore.bufferMessagPosition);
            messageAreaCursor.ToSavePosition();

            for (int i = rowsNumberOfArea - 1; i >= 0; i--)
            {
                int numRow = messageAreaCursor.ToGetLastRowNumber();
                messageAreaCursor.ToSetInPosition(Area.indentOfAreaContent,numRow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                if (arrayForDisplay[i] is Alert)
                {
                    int lastRow = messageAreaCursor.ToGetLastRowNumber();
                    messageAreaCursor.ToSetInPosition(Area.indentOfMessageAreaContent, lastRow);
                    Console.ForegroundColor = GromoMessage.alertColor;
                    Console.WriteLine(arrayForDisplay[i].textMessage);
                    messageAreaCursor.ToSavePosition();
                }
                if (arrayForDisplay[i] is Notice)
                {
                    int lastRow = messageAreaCursor.ToGetLastRowNumber();
                    messageAreaCursor.ToSetInPosition(Area.indentOfMessageAreaContent, lastRow);
                    Console.ForegroundColor = GromoMessage.noticeColor;
                    Console.WriteLine(arrayForDisplay[i].textMessage);
                    messageAreaCursor.ToSavePosition();
                }
                if (arrayForDisplay[i] is Query)
                {
                    int lastRow = messageAreaCursor.ToGetLastRowNumber();
                    messageAreaCursor.ToSetInPosition(Area.indentOfMessageAreaContent,lastRow);
                    Console.ForegroundColor = GromoMessage.queryColor;
                    Console.WriteLine(arrayForDisplay[i].textMessage);
                    messageAreaCursor.ToSavePosition();
                }

            }
        }
        public void ToShow()
        { 
            this.ToDisplaySeparator();
            this.ToDisplayTitle();
            this.ToDisplaySeparator();
            messageAreaCursor.ToSetInPosition(Area.indentOfAreaContent, messageAreaCursor.ToGetLastRowNumber());
            messageAreaCursor.ToSavePosition();
            messageAreaCursorPositionStore.bufferMessagPosition = messageAreaCursor.currentPosition;
            this.ToDisplayBuffer();
            this.ToDisplaySeparator();
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
