using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;

namespace GromoBot2.IO.Areas
{
    public class MainMenuArea:Area
    {
        string titleName = "Main Menu Area";
        string areaSeparator = "*************************************";
        Cursor mainMenuAreaCursor;
        CursorPositionStore mainMenuAreaCursorPositionStore;
        public MainMenuArea()
        {
            mainMenuAreaCursor = new Cursor();
            mainMenuAreaCursorPositionStore = new CursorPositionStore();
        }
        public Cursor areaCursor { 
            get { return mainMenuAreaCursor; }
            set { mainMenuAreaCursor = value; } }
        public CursorPositionStore areaCursorPositionStore {
            get { return mainMenuAreaCursorPositionStore; }
            set { mainMenuAreaCursorPositionStore = value; }
        }
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
            byte lastRow = mainMenuAreaCursor.ToGetRowNumber(mainMenuAreaCursor.currentPosition);
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaTitle, lastRow);
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
            mainMenuAreaCursor.ToSavePosition();
        }
        public override void ToDisplaySeparator()
        {
            byte lastRow = mainMenuAreaCursor.ToGetRowNumber(mainMenuAreaCursor.currentPosition);
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator,lastRow);
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
            mainMenuAreaCursor.ToSavePosition();
        }
        public void ToDisplayItems()
        {
            string[] itemsArray = StoreSignsForAreas.mainMenuAreaItems;
            foreach (string item in itemsArray)
            {
                byte lastRowNum = mainMenuAreaCursor.ToGetLastRowNumber();
                mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaContent, lastRowNum);
                
                Console.WriteLine(item);

                mainMenuAreaCursor.ToSavePosition();
            }
            mainMenuAreaCursor.ToSavePosition();
        }
        public void ToShow()
        {
            this.ToDisplaySeparator();
            this.ToDisplayTitle();
            this.ToDisplaySeparator();
            this.ToDisplayItems();
            this.ToDisplaySeparator();
        }
        public void ToDesignateCursorParts(Cursor cursor, CursorPositionStore curPosStore)
        {
            areaCursor = cursor;
            areaCursorPositionStore = curPosStore;
        }
    }
}
