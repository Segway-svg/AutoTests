using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UnitTest1
{
    public class Driver
    {
        private Driver()
        {
        }

        private static IWebDriver _driver = null;

        public static IWebDriver GetInstance()
        {
            if (_driver == null)
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                _driver = new ChromeDriver("85");
            }

            return _driver;
        }
    }
}