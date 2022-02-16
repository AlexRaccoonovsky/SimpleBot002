using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    // TODO: Rename name of class

    public  class AccessTemplatesStore
    {
        public int quanItemsMainMenu  = SignsOfMenuItemsStore.mainMenuItems.Length;
        public MenuItemStates[] accessOfMainMenu { get; private set; }
        // TODO: Rename?
        public MenuItemStates[] ToInitAccessPrimaryMainMenu()
        {
            // TODO:Definite quantOfAr
            accessOfMainMenu = new MenuItemStates[7] {
                MenuItemStates.Enable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Enable,
                MenuItemStates.Enable };

            return accessOfMainMenu;
        
        }
    }
}
