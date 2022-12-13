using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UnitTestProject.FirstCase
{
    public class Driver
    {
        private Driver()
        {
            // TODO factory
            ChromeOptions chromeOptions = new ChromeOptions();
            
            chromeOptions.AddArgument("--incognito");
            chromeOptions.AddArgument("--lang=en-GB");
            
            new DriverManager().SetUpDriver(new ChromeConfig());
            
            _driver = new ChromeDriver(chromeOptions);
            _driver.Manage().Window.Maximize();
        }

        private static IWebDriver _driver;

        public static IWebDriver GetInstance()
        {
            if (_driver == null)
            {
                new Driver();
            }
            return _driver;
        }
    }
}