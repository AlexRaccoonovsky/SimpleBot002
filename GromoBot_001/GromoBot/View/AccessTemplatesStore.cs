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
        public TypeOfItems[] accessOfMainMenu { get; private set; }
        public TypeOfItems[] ToInitAccessPrimaryMainMenu()
        {
            // TODO:Definite quantOfAr
            accessOfMainMenu = new TypeOfItems[7] {
                TypeOfItems.Enable,
                TypeOfItems.Disable,
                TypeOfItems.Disable,
                TypeOfItems.Disable,
                TypeOfItems.Disable,
                TypeOfItems.Enable,
                TypeOfItems.Enable };

            return accessOfMainMenu;
        
        }
    }
}
