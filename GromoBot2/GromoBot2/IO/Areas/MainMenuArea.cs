using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;
using GromoBot2.GromoExceptions.IOExceptions;
using GromoBot2.GromoExceptions;

namespace GromoBot2.IO.Areas
{
    public class MainMenuArea:Area
    {
        string titleName = "Main Menu Area";
        string areaSeparator = "*************************************";

        Cursor mainMenuAreaCursor;
        CursorPositionStore mainMenuAreaCursorPositionStore;

        string[] menuItemsArray;
        int amountLinesOfArea;
        MenuItemsState[] currTemplate;

        const ConsoleColor activeColorOfItem = ConsoleColor.Gray;
        const ConsoleColor inactiveColorOfItem = ConsoleColor.DarkGray;

        

        public MainMenuArea()
        {
            menuItemsArray = StoreSignsForAreas.mainMenuAreaItems;
            amountLinesOfArea = menuItemsArray.Length;
            currentTemplate = TemplatesOfMenuItems.StartUpTemplate;
            mainMenuAreaCursor = new Cursor();
            mainMenuAreaCursorPositionStore = new CursorPositionStore();
        }
        public override Cursor areaCursor { 
            get { return mainMenuAreaCursor; }
            set { mainMenuAreaCursor = value; } }
        public override CursorPositionStore areaCursorPositionStore {
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
        public MenuItemsState[] currentTemplate
        {
            get { return currTemplate; }
            set { currTemplate = value; }
        }
        public override void ToDisplayTitle()
        {
            int lastRow = mainMenuAreaCursor.ToGetLastRowNumber();
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaTitle, lastRow);
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
            mainMenuAreaCursor.ToSavePosition();
        }
        public override void ToDisplaySeparator()
        {
            int lastRow = mainMenuAreaCursor.ToGetLastRowNumber();
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator,lastRow);
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
            mainMenuAreaCursor.ToSavePosition();
        }
        public void ToDisplayItems()
        {
            try
            {
                if (IsEqualArealLinesAndTemplateLength())
                {
                    ToSetInFirstLine();
                    for (int counterOfLine = 1; counterOfLine <= amountLinesOfArea; counterOfLine++)
                    {
                        int indexOfItemsArray = counterOfLine - 1;
                        int indexOfTemplateArray = indexOfItemsArray;

                        if ( currTemplate[indexOfTemplateArray]== MenuItemsState.Enabled)
                        {
                            Console.ForegroundColor = activeColorOfItem;
                            Console.WriteLine(menuItemsArray[indexOfItemsArray]);
                        }
                        if (currTemplate[indexOfTemplateArray]== MenuItemsState.Disabled)
                        {
                            Console.ForegroundColor = inactiveColorOfItem;
                            Console.WriteLine(menuItemsArray[indexOfItemsArray]);
                        }
                    }


                }
                else
                {
                    string message = StoreMessagesOfErrors.AmountArealLinesAndTemplateSizeDifferentError;
                    string cause = "Attempt of Main Menu items presentation";
                    DateTime time = DateTime.Now;
                    throw new DifferentSizeException(message, cause, time);
                }

            }
            catch (DifferentSizeException ex)
            {
                // TODO: Alert insert
            }

            finally 
            {
                // TODO: ?SavePosition?
                mainMenuAreaCursor.ToSavePosition();
            }
           
            
        }
        void ToClear()
        {
            int amountOfAreaLines = menuItemsArray.Length;
            for (int counterLine = 1; counterLine <= amountOfAreaLines;counterLine++)
            {
                Console.Write(new String(' ', Console.BufferWidth));
            }
        }
        public void ToRefreshMenuTemplate()
        {
           ToDisplayItems();
        }
        public void ToShow()
        {
            ToDisplaySeparator();
            ToDisplayTitle();
            ToDisplaySeparator();
            ToSaveFirstLineOfItems();
            ToDisplayItems();
            ToDisplaySeparator();
        }
        bool IsEqualArealLinesAndTemplateLength()
        {
            if (amountLinesOfArea == currentTemplate.Length)
                return true;
            else 
                return false;
        }
        void ToSaveFirstLineOfItems()
        { 
            int numRowOfFirstItem = mainMenuAreaCursor.ToGetLastRowNumber();
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaContent, numRowOfFirstItem);
            mainMenuAreaCursor.ToSavePosition();
            mainMenuAreaCursorPositionStore.MainMenuPosition = mainMenuAreaCursor.currentPosition;
        }
        void ToSetInFirstLine()
        {
            mainMenuAreaCursor.ToSetInPosition(mainMenuAreaCursorPositionStore.MainMenuPosition);

        }




    }
}
