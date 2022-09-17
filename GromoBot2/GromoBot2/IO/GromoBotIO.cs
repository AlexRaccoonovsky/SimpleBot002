using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.UserInput;
using GromoBot2.IO.Screens;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;
using GromoBot2.IO.Areas;
using GromoBot2.GromoExceptions;
using GromoBot2.GromoExceptions.IOExceptions;


namespace GromoBot2.IO
{
    public class GromoBotIO
    {
        MainMenuScreen mainMenuScreen;
        PortfolioDefinitionScreen portfolioDefinitionScreen;
        public Screen? currentScreen;
        ErrorHandler errorHandler;
        MainMenuUserInput mainMenuUserInput;
        public GromoBotIO()
        { 
            ToInitializeWindow();
            
        }
        //   internal ErrorHandler IOErrorHandler
        //   { get { return errorHandler; }
        //     set { errorHandler = value; }
        //   }    
        public MainMenuUserInput MainMenuUserInput 
        { 
            get { return mainMenuUserInput; } 
        }
        void ToSubscribeOnMainMenuEvent()
        {
            mainMenuUserInput.UserInputIsNotNumberExcep += ToTreatException;
        }
        public void ToShowMainMenuScreen()
        {
            ToInitializeMainMenuScreen();
            mainMenuScreen.ToShow();
        }
        public void ToShowPortfolioDefinitionScreen()
        {
            ToInitializePortfolioDefinitionScreen();
            portfolioDefinitionScreen.ToShow();
        }
        public void ToDisplayNewMessage(GromoMessage msg)
        {
            mainMenuScreen.ToShowNewMessage(msg);

        }
        public void ToDisplayGromoState(StateOfGromo state)
        {
            mainMenuScreen.ToRefreshGromoStateArea(state);
        }
        //  public void ToSetTemplateForMainMenuScreen(MenuItemsState[] template)
        //  {
        //      mainMenuScreen.templateOfMenuItems = template;
        //  }
        public void ToRefreshMainMenuTemplateBy(MenuItemsState[] template)
        {
            mainMenuScreen.ToRefreshMenuByTemplate(template);
        }
        public MenuItemsState[] ToGetCurrentTemplate()
        { 
            return mainMenuScreen.TemplateOfMenuItems;
        }
        public void ToCloseMainMenuScreen()
        {
           mainMenuScreen.ToHide();
            // TODO: Need to delete object
        }
        public void ToClosePortfolioDefinitionScreen()
        { 
            portfolioDefinitionScreen.ToHide();
        }
        void ToInitializeMainMenuScreen()
        {
            mainMenuScreen = new MainMenuScreen();
            mainMenuUserInput = new MainMenuUserInput();
            ToSubscribeOnMainMenuEvent();
        }
        void ToInitializePortfolioDefinitionScreen()
        {
            portfolioDefinitionScreen = new PortfolioDefinitionScreen();
        }
        void ToInitializeWindow()
        {
            // TODO: Set width & Height by max value
            Console.Title = "GromoBot";
            Console.BufferWidth = 120;
            Console.WindowWidth = Console.BufferWidth - 1;
            Console.BufferHeight = 50;
            Console.WindowHeight = Console.BufferHeight - 1;
        }
        void ToTreatException(object sender,GromoExceptionEventArgs args)
        {
            string nameOfSender = sender.ToString();
            string strExceptionFrom = string.Concat(StoreTextsOfAlert.ErrorInModule,nameOfSender);
            Alert exceprionFrom = new Alert(strExceptionFrom);
            ToDisplayNewMessage(exceprionFrom);
            
            string messageOfError = args.msgArg;
            string msgException = string.Concat(StoreTextsOfAlert.MessageIS, messageOfError);
            Alert messageOfAlert = new Alert(msgException);
            ToDisplayNewMessage(messageOfAlert);
        }
    }
}
