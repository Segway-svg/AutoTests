using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject.CustomConfigurations;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UnitTestProject.CommonEntities
{
    public class Driver
    {
        private Driver()
        {
            // TODO factory
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");

            if (JsonConfigurator.GetConfigurationData().Language == "Rus")
            {
                chromeOptions.AddArgument("--lang=rus");
            }
            else
            {
                chromeOptions.AddArgument("--lang=en-GB");
            }
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver(chromeOptions);
            _driver.Manage().Window.Maximize();
        }

        private static WebDriver _driver;

        public static WebDriver GetInstance()
        {
            if (_driver == null)
            {
                new Driver();
            }
            return _driver;
        }
    }
}