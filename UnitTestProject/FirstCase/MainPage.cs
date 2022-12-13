using OpenQA.Selenium;
using UnitTestProject.CustomConfigurations;

namespace UnitTestProject.FirstCase
{
    public class MainPage
    {
        private readonly By _aboutButtonLocator = By.XPath("//*[@id='global_header']" +
                                                           "//a[contains(text(), 'ABOUT')]");
        
        private readonly By _storeButtonLocator = By.XPath("//*[@id='global_header']" +
                                                           "//a[@data-tooltip-content='.submenu_store']");
                
        private readonly By _statsPeakOnlineLocator = By.XPath("//*[@id='about_greeting']" +
                                                               "/div[3]/div[1]");
        
        private readonly By _statsOnlineNowLocator = By.XPath("//*[@id='about_greeting']" +
                                                              "/div[3]/div[2]");
        
        public bool OpenSteam()
        {
            string steamUrl = JsonConfigurator.GetConfigurationData().SteamUrl;
            try
            {
                Driver.GetInstance().Navigate().GoToUrl(steamUrl);
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public bool ClickAboutButton()
        {
            IWebElement aboutButton;
            try
            {
                aboutButton = Driver.GetInstance().FindElement(_aboutButtonLocator);
            }
            catch
            {
                return false;
            }
            aboutButton.Click();
            return true;
        }

        public string CompareNumberOfPlayers()
        {
            // TODO
            return "";
        }
        
        public bool ClickStoreButton()
        {
            IWebElement storeButton;
            try
            {
                storeButton = Driver.GetInstance().FindElement(_storeButtonLocator);
            }
            catch
            {
                return false;
            }
            storeButton.Click();
            return true;
        }
    }
}