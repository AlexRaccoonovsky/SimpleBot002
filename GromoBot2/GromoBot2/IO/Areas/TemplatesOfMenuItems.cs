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
        static MenuItemsState[] TemplateOfStartUp = new MenuItemsState[]
            { 
                MenuItemsState.Enabled,
                MenuItemsState.Disabled,
                MenuItemsState.Disabled,
                MenuItemsState.Disabled,
                MenuItemsState.Disabled,
                MenuItemsState.Disabled,
                MenuItemsState.Disabled,
            };
        static MenuItemsState[] TemplateOfConnected = new MenuItemsState[]
    {
                MenuItemsState.Disabled,
                MenuItemsState.Enabled,
                MenuItemsState.Enabled,
                MenuItemsState.Disabled,
                MenuItemsState.Disabled,
                MenuItemsState.Enabled,
                MenuItemsState.Disabled,
    };

    }
}
