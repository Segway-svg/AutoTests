using NUnit.Framework;
using OpenQA.Selenium;

namespace UnitTestProject
{
    public class Tests
    {
        private static IWebDriver _driver;
        private string steamUrl = "https://store.steampowered.com/";

        [SetUp]
        public void Setup()
        {
            _driver = Driver.GetInstance();
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver = null;
        }
        
        [Test]
        public void OpenSteamTest()
        {
            _driver.Navigate().GoToUrl(steamUrl);
            Assert.Pass();
        }
        
        [Test]
        public void ClickAboutButtonTest()
        {
            // TODO
            Assert.Pass();
        }
        
        [Test]
        public void CompareNumberOfPlayersTest()
        {
            // TODO
            Assert.Pass();
        }

        [Test]
        public void OpenStoreButtonTest()
        {
            Assert.Pass();
        }
    }
}