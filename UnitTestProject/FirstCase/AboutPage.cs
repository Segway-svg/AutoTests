using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.FirstCase
{
    public class AboutPage
    {
        private readonly By _storeButtonLocator = By.XPath("//*[@id='global_header']" +
                                                           "//a[@data-tooltip-content='.submenu_store']");
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
