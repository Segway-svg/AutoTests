using MyTest.CustomConfigurations;
using MyTest.Factory;
using OpenQA.Selenium;

namespace MyTest.CommonEntities
{
    public class Driver
    {
        private Driver()
        {
            IBrowser creator = new ChromeBrowser();
            IProduction chrome = creator.Create();
            _driver = chrome.Release(language);
        }

        private static WebDriver _driver;
        private static string language = JsonConfigurator.GetConfigurationData().DefaultLanguage;

        public static WebDriver GetInstance()
        {
            if (_driver == null)
            {
                new Driver();
            }
            return _driver;
        }

        public static void OpenSteam()
        {
            GetInstance().Navigate().GoToUrl(JsonConfigurator.GetConfigurationData().SteamUrl);
        } 
        
        public static void MakeNullable()
        {
            _driver = null;
        }

        public static void ChooseLanguage(string _language)
        {
            language = _language;
        }
    }
}