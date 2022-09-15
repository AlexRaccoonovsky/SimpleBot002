using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.CursorParts;
using GromoBot2.GromoExceptions.IOExceptions;
using GromoBot2.GromoExceptions;
using GromoBot2.IO.GromoMessages;

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

        ErrorHandler errorHandler;

        public MainMenuArea()
        {
            menuItemsArray = StoreSignsForAreas.mainMenuAreaItems;
            amountLinesOfArea = menuItemsArray.Length;
            currTemplate = TemplatesOfMenuItems.AwaitingTemplate;

            mainMenuAreaCursor = new Cursor();
            mainMenuAreaCursorPositionStore = new CursorPositionStore();
            //errorHandler = new ErrorHandler();
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
            get { return areaSeparator;  }
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
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator, lastRow);
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
            mainMenuAreaCursor.ToSavePosition();
        }
        public void ToRefreshMenuItemsByTemplate(MenuItemsState[] template)
        {
            currTemplate = template;
            ToClearMenu();
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
        public void ToDisplayItems()
        {
            try
            {
                if (IsEqualArealLinesAndTemplateLength())
                {
                    for (int counterOfLine = 1; counterOfLine <= amountLinesOfArea; counterOfLine++)
                    {
                        int indexOfItemsArray = counterOfLine - 1;
                        
                        if (counterOfLine == 1) 
                        { 
                            ToSetInFirstLineOfArea();
                            ToPlotMenuItemByIndex(indexOfItemsArray);
                            mainMenuAreaCursor.ToSavePosition();
                        }
                        else
                        {
                            int numRowOfAreaLine = mainMenuAreaCursor.ToGetLastRowNumber();
                            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaContent, numRowOfAreaLine);
                            ToPlotMenuItemByIndex(indexOfItemsArray);
                            mainMenuAreaCursor.ToSavePosition();
                        }
                    }
                }
                else
                {
                    string message = StoreMessagesOfErrors.AmountAreaLinesAndTemplateSizeDifferentError;
                    string cause = "Attempt of Main Menu items presentation";
                    DateTime time = DateTime.Now;
                    throw new DifferentSizeException(message, cause, time);
                }
            }
            catch (DifferentSizeException ex)
            {
                errorHandler.ToShowAlert(ex);
            }
            catch (Exception ex)
            {
                errorHandler.ToShowAlert(ex);
            }
            finally 
            {

            }
        }

        void ToClearMenu()
        {
            ToSetInFirstLineOfArea();
            int amountOfAreaLines = menuItemsArray.Length;
            for (int counterLine = 1; counterLine <= amountOfAreaLines;counterLine++)
            {
                Console.Write(new String(' ', Console.BufferWidth));
            }
        }
        void ToPlotMenuItemByIndex(int index)
        {

            if (currTemplate[index] == MenuItemsState.Enabled)
            {
                Console.ForegroundColor = activeColorOfItem;
                Console.WriteLine(menuItemsArray[index]);
            }
            if (currTemplate[index] == MenuItemsState.Disabled)
            {
                Console.ForegroundColor = inactiveColorOfItem;
                Console.WriteLine(menuItemsArray[index]);
            }
        }
        bool IsEqualArealLinesAndTemplateLength()
        {
            if (amountLinesOfArea == currTemplate.Length)
                return true;
            else 
                return false;
        }
        void ToSaveFirstLineOfItems()
        {
            int numberOfRow = mainMenuAreaCursor.ToGetLastRowNumber();
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaContent, numberOfRow);
            mainMenuAreaCursor.ToSavePosition();
            mainMenuAreaCursorPositionStore.MainMenuPosition = mainMenuAreaCursor.currentPosition;
        }
        void ToSetInFirstLineOfArea()
        {
            mainMenuAreaCursor.ToSetInPosition(mainMenuAreaCursorPositionStore.MainMenuPosition);
        }
    }
}
