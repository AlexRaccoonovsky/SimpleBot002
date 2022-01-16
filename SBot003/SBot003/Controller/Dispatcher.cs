using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBot003.View;
using SBot003.DTO;
;

namespace SBot003.Controller
{
    public class Dispatcher
    {
        MessagePresenter messagePresenter;
        public void StartToDispatch()
        {
            this.ToInitInvironment();
            messagePresenter.ShowMainMenu();
        }

        internal void ToInitInvironment()
        {
            // Initialize MessagePresenter
            messagePresenter = new MessagePresenter();
        }

        internal Answer ToTrimAndCheckAnswer(Answer ans)
        {
            // Trimming Spaces
            msg = (ans.messageOfAnswer).Trim();
            // 

        }

    }
}
