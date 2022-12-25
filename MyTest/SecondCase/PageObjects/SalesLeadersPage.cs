using System;
using MyTest.CommonEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyTest.SecondCase.PageObjects
{
    public class SalesLeadersPage
    {
        private readonly By _salesLeadersUniquePageLocator = By.XPath("//*[contains(@id, 'application_root')]");
        private readonly By _watchMoreLocator = By.XPath("//*[contains (@class, 'DialogButton')]");
        
        public bool IsSalesLeadersPageOpened()
        {
            Driver.GetInstance().FindElement(_salesLeadersUniquePageLocator);
            return true;
        } 
        
        public void ClickWatchMoreButton()
        {
            IJavaScriptExecutor ts = Driver.GetInstance();
            ts.ExecuteScript("window.scrollBy(0, document.body.scrollHeight)");

            IWebElement watchMoreButton = GetTextWithWait(_watchMoreLocator);
            
            watchMoreButton.Click();
        }
        
        private IWebElement GetTextWithWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            IWebElement webElement = Driver.GetInstance().FindElement(locator);
            
            return webElement;
        }
    }
}