using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MyTest.Factory;

public class Edge : IProduction
{
    public WebDriver Release(string language)
    { 
        EdgeOptions edgeOptions = new EdgeOptions();
        edgeOptions.AddArgument("--incognito");
        edgeOptions.AddArgument(language);
        
        new DriverManager().SetUpDriver(new EdgeConfig());
        var webDriver = new EdgeDriver(edgeOptions);
        webDriver.Manage().Window.Maximize();

        return webDriver;
    }
}