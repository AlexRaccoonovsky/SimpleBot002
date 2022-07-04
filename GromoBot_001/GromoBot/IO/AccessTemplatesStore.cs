using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GromoBot.View
{
    // TODO: Rename name of class

    public static class AccessTemplatesStore
    {
        
       // TODO: Rename?
        public static MenuItemStates[] ToInitAccessTemplatePrimaryMainMenu()
        {
            // TODO:Definite quantOfAr
            MenuItemStates[] accessTemplateOfMainMenu = new MenuItemStates[7]
            {
                MenuItemStates.Enable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Disable,
                MenuItemStates.Enable 
            };

            return accessTemplateOfMainMenu;
        
        }
    }
}
