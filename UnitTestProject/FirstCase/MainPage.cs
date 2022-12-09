using System.Text.Json.Nodes;
using UnitTestProject.CustomConfigurations;

namespace UnitTestProject.FirstCase
{
    public class MainPage
    {
        private string _nameInputLocator;
        private string _loginButtonLocator;
        
        public void OpenSteam()
        {
            var driver = Driver.GetInstance();
            string steamUrl = JsonConfigurator.GetConfigurationData().SteamUrl;
            driver.Navigate().GoToUrl(steamUrl);
        }
        
        public void ClickAboutButton()
        {
            // TODO
        }
        
        public string CompareNumberOfPlayers()
        {
            // TODO
            return "";
        }
        
        public void ClickStoreButton()
        {
            // TODO
        }
    }
}