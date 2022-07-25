using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Areas
{
    public class StateParameterArea:Area
    {
        string titleName = "StateParameterArea";
        string areaSeparator = "+++++++++++++++++++++++++++++++++++++";
        Cursor stateParameterAreaCursor;
        CursorPositionStore stateParametersAreaCursorPositionStore;
        public StateParameterArea()
        {
            stateParameterAreaCursor = new Cursor();
            stateParametersAreaCursorPositionStore = new CursorPositionStore();
        }
         
        public override Cursor areaCursor {
            get => stateParameterAreaCursor;
            set => stateParameterAreaCursor = value;}
        public override CursorPositionStore areaCursorPositionStore { 
            get => stateParametersAreaCursorPositionStore;
            set => stateParametersAreaCursorPositionStore = value;}
        public override string areaTitleName 
        {
            get => titleName;
        }
        public override string areaSeparatorType
        {
            get => areaSeparator;
        }
        public override void ToDisplayTitle()
        {
            byte lastRow = stateParameterAreaCursor.ToGetLastRowNumber();
            stateParameterAreaCursor.ToSetInPosition(Area.indentOfAreaTitle, lastRow);
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
            stateParameterAreaCursor.ToSavePosition();
        }
        public override void ToDisplaySeparator()
        {
            byte lastRow = stateParameterAreaCursor.ToGetLastRowNumber();
            stateParameterAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator, lastRow);
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.WriteLine(areaSeparator);
            stateParameterAreaCursor.ToSavePosition();
        }
        public void ToDisplayStateParameters()
        {
            byte lastRow = stateParameterAreaCursor.ToGetLastRowNumber() ;
            stateParameterAreaCursor.ToSetInPosition(Area.indentOfAreaContent, lastRow);
            Console.WriteLine("+++STATEOFGROMO+++");
            stateParameterAreaCursor.ToSavePosition() ;
        }
        public void ToShow()
        { 
            this.ToDisplaySeparator();
            this.ToDisplayTitle();
            this.ToDisplaySeparator();
            this.ToDisplayStateParameters();
            this.ToDisplayStateParameters();
        }

    }
}
