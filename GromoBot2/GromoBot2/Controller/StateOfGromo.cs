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
        ConnectionStates stateOfConnection;
        Portfolio gromoPortfolio;
        Security gromoSecurity;
        public ConnectionStates ConnectionState 
        { 
            get { return stateOfConnection; }
            set { stateOfConnection = value; }
        }
        public Portfolio SelectedPortfolio
        {
            get { return gromoPortfolio; }
            set { gromoPortfolio = value; }
        }
        public Security SelectedSecurity
        {
            get { return gromoSecurity; }
            set { gromoSecurity = value; }
        }
      

        #region "Definition delegates for Gromo Events"
        // TODO: sender is StateOfGromo?
        public delegate void GromoStateChangedHandler(object sender, GromoStateChangedEventArgs args);
        #endregion
        #region "Definition events for Gromo Controller"
        public event GromoStateChangedHandler GromoStateChanged;
        #endregion
        public StateOfGromo()
        {
            ConnectionState = ConnectionStates.Disconnected;
            Portfolio emptyPortfolio = new Portfolio();
            emptyPortfolio.Name = "EmptyPortfolio";
            SelectedPortfolio = emptyPortfolio;

            Security emptySecurity = new Security();
            emptySecurity.Id = "EmptySecurity";
            SelectedSecurity = emptySecurity;
        }
        public void ToSetConnectionState(ConnectionStates connState)
        {
            if (ConnectionState != connState)
            {
                ConnectionState = connState;
                ToNotifyAboutChangedState();
            }
           
        }
        public void ToSetPortfolio(Portfolio portfolio)
        {
            if (SelectedPortfolio != portfolio)
            {
                this.SelectedPortfolio = portfolio;
                ToNotifyAboutChangedPortfolio();
            }
            
        }
        public void ToSetSecurity(Security security)
        {
            if (gromoSecurity != security)
            {
                gromoSecurity = security;
                ToNotifyAboutChangedSecurity();
            }
        }
        void ToNotifyAboutChangedState()
        {
            Notice noticeChangedState = new Notice(StoreTextsOfNotices.ConnectionStateChanged);
            GromoStateChangedEventArgs args = new GromoStateChangedEventArgs(noticeChangedState);
            GromoStateChanged?.Invoke(this, args);
        }
        void ToNotifyAboutChangedPortfolio()
        {
            Notice noticeChangedPortfolio = new Notice(StoreTextsOfNotices.SelectedPortfolioChanged);
            GromoStateChangedEventArgs arg = new GromoStateChangedEventArgs(noticeChangedPortfolio);
            GromoStateChanged?.Invoke(this, arg);
        }
        void ToNotifyAboutChangedSecurity()
        {
            Notice noticeChangedSecurity = new Notice(StoreTextsOfNotices.SelectedSecurityChanged);
            GromoStateChangedEventArgs arg = new GromoStateChangedEventArgs(noticeChangedSecurity);
            GromoStateChanged?.Invoke(this,arg);
        }
    }
}
