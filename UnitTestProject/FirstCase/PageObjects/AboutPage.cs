using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.FirstCase.PageObjects;

public class AboutPage
{
    private readonly By _uniqueAboutPageLocator = By.XPath("//*[contains(@id, 'greeting')]");
    private readonly By _statsPeakOnlineLocator = By.XPath("//*[@class='online_stat'][1]");
    private readonly By _statsOnlineNowLocator = By.XPath("//*[@class='online_stat'][2]");

    public bool IsAboutPageOpened()
    {
        Driver.GetInstance().FindElement(_uniqueAboutPageLocator);
        return true;
    }

    public int GetPeakCountOfPlayers()
    {
        string peakStr = Driver.GetInstance().FindElement(_statsPeakOnlineLocator).Text;
        return Int32.Parse(peakStr.Split("\n")[^1].Replace(",", ""));
    }
    
    public int GetOnlineCountOfPlayers()
    {
        string peakStr = Driver.GetInstance().FindElement(_statsOnlineNowLocator).Text;
        return Int32.Parse(peakStr.Split("\n")[^1].Replace(",", ""));
    }
}