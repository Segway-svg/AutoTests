using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MyTest.Factory;

public class Chrome : IProduction
{
    public WebDriver Release(string language)
    {
        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--incognito");
        chromeOptions.AddArgument(language);
        
        new DriverManager().SetUpDriver(new EdgeConfig());
        var webDriver = new ChromeDriver(chromeOptions);
        webDriver.Manage().Window.Maximize();
        
        return webDriver;
    }
}