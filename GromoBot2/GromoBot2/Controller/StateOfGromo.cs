﻿using System;
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
        public ConnectionStates connectionState 
        { 
            get { return stateOfConnection; }
            set { stateOfConnection = value; }
        }
        public Portfolio selectedPortfolio
        {
            get { return gromoPortfolio; }
            set { gromoPortfolio = value; }
        }
        public Security selectedSecurity
        {
            get { return gromoSecurity; }
            set { gromoSecurity = value; }
        }
      

        #region "Definition delegates for Gromo Events"
        public delegate void GromoStateChangedHandler(StateOfGromo sender, GromoStateChangedEventArgs args);
        #endregion
        #region #Definition events for Gromo Controller
        public event GromoStateChangedHandler GromoStateChanged;
        #endregion
        public StateOfGromo()
        {
            connectionState = ConnectionStates.Disconnected;
            Portfolio emptyPortfolio = new Portfolio();
            emptyPortfolio.Name = "EmptyPortfolio";
            Security emptySecurity = new Security();
            emptySecurity.Id = "EmptySecurity";
            selectedPortfolio = emptyPortfolio;
            selectedSecurity = emptySecurity;
        }
        public void ToSetConnectionState(ConnectionStates connState)
        {
            if (connectionState != connState)
            {
                this.connectionState = connState;
                ToNotifyAboutChangedState();
            }
           
        }
        public void ToSetPortfolio(Portfolio portfolio)
        {
            if (selectedPortfolio != portfolio)
            {
                this.selectedPortfolio = portfolio;
                ToNotifyAboutChangedPortfolio();
            }
            
        }
        public void ToSetSecurity(Security security)
        {
            if (selectedSecurity != security)
            {
                this.selectedSecurity = security;
                ToNotifyAboutChangedSecurity();
            }
        }
        void ToNotifyAboutChangedState()
        {
            // Testing Alert. Notice is switch off
            Alert alertChangedState = new Alert(StoreTextsOfMessages.connStateChanged);
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
