using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UnitTestProject
{
    public class Driver
    {
        private Driver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver(chromeOptions);

        }

        private static IWebDriver _driver = null;

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