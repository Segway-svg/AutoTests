using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class SecondCaseTestMainPage
    {
        private readonly By _newAndRemarkableLocator = By.XPath("//*[@id='noteworthy_tab']" +
                                                                "/span/a[1]");
        
        private readonly By _salesLeadersLocator = By.XPath("//*[@id='noteworthy_flyout']//" +
                                                     "a[contains(@href, 'topselling')]");
        
        public bool ClickSalesLeadersButton()
        {
            Actions action = new Actions(Driver.GetInstance());
            action.MoveToElement(Driver.GetInstance().FindElement(_newAndRemarkableLocator));
            action.Perform();

            WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_salesLeadersLocator));
            
            IWebElement salesLeaders = Driver.GetInstance().FindElement(_salesLeadersLocator);
            salesLeaders.Click();
            return true;
        }
    }
}