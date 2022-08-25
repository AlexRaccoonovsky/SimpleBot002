using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GromoBot2.IO.Screens;
using GromoBot2.IO.GromoMessages;
using GromoBot2.Controller;
using GromoBot2.IO.Areas;


namespace GromoBot2.IO
{
    public class GromoBotIO
    {
        MainMenuScreen mainMenuScreen;
        PortfolioDefinitionScreen portfolioDefinitionScreen;
        public Screen? currentScreen;
        public GromoBotIO()
        { 
            this.ToInitializeWindow();
        }
        void ToInitializeWindow()
        {
            // TODO: Set width & Height by max value
            Console.Title = "GromoBot";
            Console.BufferWidth = 120;
            Console.WindowWidth = Console.BufferWidth - 1;
            Console.BufferHeight = 50;
            Console.WindowHeight = Console.BufferHeight - 1;
            return;
        }
        void ToInitializeMainMenuScreen()
        {
            mainMenuScreen = new MainMenuScreen();
        }
        void ToInitializePortfolioDefinitionScreen()
        {
            portfolioDefinitionScreen = new PortfolioDefinitionScreen();
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
        public void ToSetTemplateForMainMenuScreen(MenuItemsState[] template)
        {
            mainMenuScreen.templateOfMenuItems = template;
        }
        public MenuItemsState[] ToGetTemplateForMainMenuScreen()
        { 
            return mainMenuScreen.templateOfMenuItems;
        }
        public void ToCloseMainMenuScreen()
        {
           mainMenuScreen.ToHide();
        }
        public void ToClosePortfolioDefinitionScreen()
        { 
            portfolioDefinitionScreen.ToHide();
        }

            
    }
}
