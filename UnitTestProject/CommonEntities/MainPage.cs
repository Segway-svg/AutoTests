using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UnitTestProject.CommonEntities;

public class MainPage
{
    private readonly By _mainPageUniqueLocator = By.XPath("//*[contains(@id, 'module_special')]");
    private readonly By _newAndRemarkableLocator = By.XPath("//a[@class='pulldown_desktop' and contains(text(), 'Новое')]");
    private readonly By _salesLeadersLocator = By.XPath("//a[contains(@href, 'topselling')]");

    public bool IsMainPageOpened()
    {
        Driver.GetInstance().FindElement(_mainPageUniqueLocator);
        return true;
    }
    
    public void PerformSalesLeadersSubMenu()
    {
        Actions action = new Actions(Driver.GetInstance());
        action.MoveToElement(Driver.GetInstance().FindElement(_newAndRemarkableLocator));
        action.Perform();
    }
    
    public void ClickSalesLeadersButton()
    {
        WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(_salesLeadersLocator));
            
        IWebElement salesLeaders = Driver.GetInstance().FindElement(_salesLeadersLocator);
        salesLeaders.Click();
    }
}