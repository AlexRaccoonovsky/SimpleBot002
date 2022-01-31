using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.ServiceStorage;

namespace SBot003.DTO
{
    public class StateNotice:Message
    {
        // TODO: !!!Need To Change
        public string messageText { get; set; }
        // Signs for request "1. Show State Of GromoBot" of MainMenu
        public string[] txtStateSigns { get; private set; }
        // Values for or request "1. Show State Of GromoBot" of MainMenu
        public string[] valuesOfStatusSigns{ get; private set; }
        public StateNotice(string[] valuesOfGromoBotStateParams)
        {
            txtStateSigns = MenuItemsStorage.signsForGromoBotStateParam;
            valuesOfStatusSigns = valuesOfGromoBotStateParams;
        }
    }
}
