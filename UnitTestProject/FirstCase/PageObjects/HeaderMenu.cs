using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.FirstCase.PageObjects
{
    public class HeaderMenu
    {
        private readonly By _aboutButtonLocator = By.XPath("//a[contains(text(), 'ABOUT')]");
        private readonly By _storeButtonLocator = By.XPath("//a[@data-tooltip-content='.submenu_store']");
        
        public void ClickAboutButton()
        {
            IWebElement aboutButton = Driver.GetInstance().FindElement(_aboutButtonLocator);
            aboutButton.Click();
        }
        
        public void ClickStoreButton()
        {
            IWebElement storeButton = Driver.GetInstance().FindElement(_storeButtonLocator);
            storeButton.Click();
        }
    }
}
