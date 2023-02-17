﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSharp.Algo;
using GromoBot2.IO;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller.GromoCommand;
using GromoBot2.Controller.GromoCommand.MainMenuModeCommands;
using GromoBot2.Controller.Mode;
using GromoBot2.Model;
using GromoBot2.GromoExceptions;



namespace GromoBot2.Controller
{
    public class GromoBot
    {
        GromoBotIO gromoIO;
        StateOfGromo currentState;
        Mode.Mode currentMode;
        GromoConnector gromoConnector;
        public GromoBot()
        { 
            gromoIO = new GromoBotIO();
            currentState = new StateOfGromo();
            currentMode = new MainMenuMode();
            gromoConnector = new GromoConnector();
            currentState.GromoStateChanged += ToNotifyUser;
        }
        public GromoBotIO gromoBotIO
        { 
            get { return gromoIO; }
        }
        public StateOfGromo gromoState
        { 
            get { return currentState; }
        }
        public Mode.Mode CurrentMode
        {
            get { return currentMode; }
            set { currentMode = value; }
        }
        void ToShowMessage()
        {
            string text1 = "Hello!";
            string text2 = "World";
            string text3 = "from Gromobot)";
            string text4 = "1";
            string text5 = "2";
            Notice notice1 = new Notice(text1);
            Notice notice2 = new Notice(text2);
            Notice notice3 = new Notice(text3);
            Notice notice4 = new Notice(text4);
            Notice notice5 = new Notice(text5);
            Query query6 = new Query(text5);
            gromoIO.ToDisplayNewMessage(notice1);
            gromoIO.ToDisplayNewMessage(notice2);
            gromoIO.ToDisplayNewMessage(notice3);
            gromoIO.ToDisplayNewMessage(notice4);
            gromoIO.ToDisplayNewMessage(notice5);
            gromoIO.ToDisplayNewMessage(query6);
            // Need to realize
            //notice1.AddToBuffer();
            //notice1.ToDisplay()

        }
        // Test method for GromoStateChanged
        void ToNotifyUser(object state, GromoStateChangedEventArgs arg)
        { 
            gromoIO.ToDisplayNewMessage(arg.gromoMessage);
            gromoIO.ToDisplayGromoState(currentState);

        }
        
        void ToChangeGromoState()
        // Test changing of GromoState
        {
            Thread.Sleep(2000);
            currentState.ToSetConnectionState(StockSharp.Messages.ConnectionStates.Connected);
        }

        public CommandForGromo ToConvertIntoCommand(int numOfInput)
        {
            CommandForGromo command;
            command = new CommandEmpty(this);
            #region "MainMenuMode: Transformation UserInput to GromoCommand"

            if (currentMode is MainMenuMode)
            {
                if (numOfInput == 1)
                { command = new CommandConnect(this); }
                if (numOfInput == 2)
                { command = new CommandToDefinePortfolio(this); }
            }
            #endregion


            return command;
        }
        public void ToEmptyAction()
        {
            Thread.Sleep(2000);
            gromoIO.ToDisplayGromoState(currentState);
        }

        public void ToConnect()
        {
            gromoConnector.ToConnect();
        }
        public void ToDefinitePortfolio()
        {
            currentMode = new PortfolioDefinitionMode();
            gromoBotIO.ToCloseMainMenuScreen();
            gromoBotIO.ToShowPortfolioDefinitionScreen();
            currentMode.ToStart(this);
        }
        void ToSubscribeOnEvents()
        {
            #region "Subscribing on GromoConnector Events"
            //gromoConnector.
            # endregion
        }


    }
}
