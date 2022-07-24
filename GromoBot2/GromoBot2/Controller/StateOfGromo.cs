using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Messages;
using StockSharp.BusinessEntities;
using GromoBot2.IO.GromoMessages;
namespace GromoBot2.Controller
{
    public class StateOfGromo
    {
        public ConnectionStates connectionState { get; private set; }
        public Portfolio? selectedPortfolio { get; set; }
        public Security? selectedSecurity { set; get; }

        #region "Definition delegates for Gromo Events"
        public delegate void GromoStateChangedHandler(StateOfGromo sender, GromoStateChangedEventArgs args);
        #endregion
        #region #Definition events for Gromo Controller
        public event GromoStateChangedHandler GromoStateChanged;
        #endregion
        public StateOfGromo()
        {
            connectionState = ConnectionStates.Disconnected;
            selectedPortfolio = null;
            selectedSecurity = null;
        }
        public void ToSetConnectionState(ConnectionStates connState)
        {
            if (connectionState != connState)
            {
                ToNotifyAboutChangedState();
            }
            connectionState = connState;
        }
        public void ToSetPortfolio(Portfolio portfolio)
        {
            if (selectedPortfolio != portfolio)
            {
                ToNotifyAboutChangedPortfolio();
            }
            selectedPortfolio = portfolio;
        }
        public void ToSetSecurity(Security security)
        {
            if (selectedSecurity != security)
            { 
                ToNotifyAboutChangedSecurity();
            }
            selectedSecurity = security;
        }
        void ToNotifyAboutChangedState()
        {
            // Testing alert. Notice is switch off
            Alert alertChangedState = new Alert(StoreTextsOfMessages.selectedSecurityChanged);
            //Notice noticeChangedState = new Notice(StoreTextsOfMessages.connStateChanged);
            GromoStateChangedEventArgs args = new GromoStateChangedEventArgs(alertChangedState);
            GromoStateChanged?.Invoke(this, args);
        }
        void ToNotifyAboutChangedPortfolio()
        {
            Notice noticeChangedPortfolio = new Notice(StoreTextsOfMessages.selectedPortfolioChanged);
            GromoStateChangedEventArgs arg = new GromoStateChangedEventArgs(noticeChangedPortfolio);
            GromoStateChanged?.Invoke(this, arg);
        }
        void ToNotifyAboutChangedSecurity()
        {
            Notice noticeChangedSecurity = new Notice(StoreTextsOfMessages.selectedSecurityChanged);
            GromoStateChangedEventArgs arg = new GromoStateChangedEventArgs(noticeChangedSecurity);
            GromoStateChanged?.Invoke(this,arg);
        }

            
    }
}
