using System.Threading;
using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class AllSalesLeaders
    {
        private readonly By _osCheckBoxLocator = By.XPath("//*[@id='additional_search_options']" +
                                                          "/div[10]/div[2]/div[2]/span");
        
        public bool ClickOsButton()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor ts = Driver.GetInstance();
            ts.ExecuteScript("window.scrollBy(0,1200);");
            Thread.Sleep(5000);
            IWebElement osCheckBoxButton = Driver.GetInstance().FindElement(_osCheckBoxLocator);
            osCheckBoxButton.Click();
            
            Thread.Sleep(5000);
            return true;
        }
    }
}