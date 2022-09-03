using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Areas;

namespace GromoBot2.IO.Areas
{
    internal static class TemplatesOfMenuItems
    {
        public static MenuItemsState[] StartUpTemplate = new MenuItemsState[]
            { 
                MenuItemsState.Enabled,             // 1. Connect",
                MenuItemsState.Disabled,            // 2. Set Portfolio",
                MenuItemsState.Disabled,            // 3. Set Security",
                MenuItemsState.Disabled,            // 4. ObserverMode",
                MenuItemsState.Disabled,            // 5. TraderMode",
                MenuItemsState.Disabled,            // 6. Disconnect",
                MenuItemsState.Enabled,             // 7. Exit"
            };
        public static MenuItemsState[] TemplateConnected = new MenuItemsState[]
            {
                MenuItemsState.Disabled,           // 1. Connect",
                MenuItemsState.Enabled,            // 2. Set Portfolio",
                MenuItemsState.Enabled,            // 3. Set Security",
                MenuItemsState.Disabled,           // 4. ObserverMode",
                MenuItemsState.Disabled,           // 5. TraderMode",
                MenuItemsState.Enabled,            // 6. Disconnect",
                MenuItemsState.Disabled,           // 7. Exit"
           };
        public static MenuItemsState[] TemplatePortfolioSelected = new MenuItemsState[]
            { 
                MenuItemsState.Disabled,            // 1. Connect",
                MenuItemsState.Enabled,             // 2. Set Portfolio",
                MenuItemsState.Enabled,             // 3. Set Security",
                MenuItemsState.Disabled,            // 4. ObserverMode",
                MenuItemsState.Disabled,            // 5. TraderMode",
                MenuItemsState.Enabled,             // 6. Disconnect",
                MenuItemsState.Disabled,            // 7. Exit"
            };
        public static MenuItemsState[] AwaitingTemplate = new MenuItemsState[]
    {
                MenuItemsState.Disabled,             // 1. Connect",
                MenuItemsState.Disabled,             // 2. Set Portfolio",
                MenuItemsState.Disabled,             // 3. Set Security",
                MenuItemsState.Disabled,             // 4. ObserverMode",
                MenuItemsState.Disabled,             // 5. TraderMode",
                MenuItemsState.Disabled,             // 6. Disconnect",
                MenuItemsState.Disabled,             // 7. Exit"
    };

    }
}
