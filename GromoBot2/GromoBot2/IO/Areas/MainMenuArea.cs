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
        const ConsoleColor activeColorOfItem = ConsoleColor.Gray;
        const ConsoleColor inactiveColorOfItem = ConsoleColor.DarkGray;
        Cursor mainMenuAreaCursor;
        CursorPositionStore mainMenuAreaCursorPositionStore;
        MenuItemsState[] currTemplate;
        public MainMenuArea()
        {
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
            byte lastRow = mainMenuAreaCursor.ToGetLastRowNumber();
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaTitle, lastRow);
            Console.BackgroundColor = Area.titleAreaColorBack;
            Console.ForegroundColor = Area.titleAreaColorFront;
            Console.WriteLine(titleName);
            mainMenuAreaCursor.ToSavePosition();
        }
        public override void ToDisplaySeparator()
        {
            byte lastRow = mainMenuAreaCursor.ToGetLastRowNumber();
            mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaSeparator,lastRow);
            Console.ForegroundColor = Area.separatorAreaColorFront;
            Console.BackgroundColor = Area.separatorAreaColorBack;
            Console.WriteLine(areaSeparator);
            mainMenuAreaCursor.ToSavePosition();
        }
        public void ToDisplayItems()
        {
            string[] itemsArray = StoreSignsForAreas.mainMenuAreaItems;
            if (IsEqualSize(itemsArray,currentTemplate))
            { 
                for (int i = 0; i < itemsArray.Length; i++)
                     {
                       byte lastRowNum = mainMenuAreaCursor.ToGetLastRowNumber();
                       mainMenuAreaCursor.ToSetInPosition(Area.indentOfAreaContent, lastRowNum);
                       mainMenuAreaCursorPositionStore.MainMenuPosition = mainMenuAreaCursor.currentPosition; 
                        if (currentTemplate[i] == MenuItemsState.Enabled)
                             {
                                   Console.ForegroundColor = activeColorOfItem;
                                   Console.WriteLine(itemsArray[i]);
                                   mainMenuAreaCursor.ToSavePosition();
                             }
                        else
                             {
                                   Console.ForegroundColor = inactiveColorOfItem;
                                   Console.WriteLine(itemsArray[i]);
                                   mainMenuAreaCursor.ToSavePosition();
                             }
                     }
            }
            else
            {
                throw new Exception("ItemsArray&Template has a different sizes!");
            }
            mainMenuAreaCursor.ToSavePosition();
        }
        public void ToRefreshMenuTemplate()
        {
            string[] itemsArray = StoreSignsForAreas.mainMenuAreaItems;
            if (IsEqualSize(itemsArray, currentTemplate))
            {
                for (int i = 0; i < itemsArray.Length; i++)
                {
                    mainMenuAreaCursor.ToSetInPosition(mainMenuAreaCursorPositionStore.MainMenuPosition);
                    mainMenuAreaCursorPositionStore.MainMenuPosition = mainMenuAreaCursor.currentPosition;
                    if (currentTemplate[i] == MenuItemsState.Enabled)
                    {
                        Console.ForegroundColor = activeColorOfItem;
                        Console.WriteLine(itemsArray[i]);
                        mainMenuAreaCursor.ToSavePosition();
                    }
                    else
                    {
                        Console.ForegroundColor = inactiveColorOfItem;
                        Console.WriteLine(itemsArray[i]);
                        mainMenuAreaCursor.ToSavePosition();
                    }
                }
            }
            else
            {
                throw new Exception("ItemsArray&Template has a different sizes!");
            }

        }
        public void ToShow()
        {
            this.ToDisplaySeparator();
            this.ToDisplayTitle();
            this.ToDisplaySeparator();
            this.ToDisplayItems();
            this.ToDisplaySeparator();
        }
        bool IsEqualSize(string[] itemsArray, MenuItemsState[] currentTemplate)
        {
            if (itemsArray.Length == currentTemplate.Length)
                return true;
            else 
                return false;
        }
        
    }
}
