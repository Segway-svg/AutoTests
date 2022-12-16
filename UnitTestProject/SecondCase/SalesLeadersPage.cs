using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class SalesLeadersPage
    {
        private readonly By _watchMoreLocator = By.XPath("//*[contains (@class, 'DialogButton')]");
        
        public bool ClickWatchMoreButton()
        {
            System.Threading.Thread.Sleep(5000);
            IJavaScriptExecutor ts = Driver.GetInstance();
            ts.ExecuteScript("window.scrollBy(0, document.body.scrollHeight)");

            System.Threading.Thread.Sleep(5000);

            IWebElement watchMoreButton = Driver.GetInstance().FindElement(_watchMoreLocator);
            watchMoreButton.Click();

            return true;
        }
    }
}