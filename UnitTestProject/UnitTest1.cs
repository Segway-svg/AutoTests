using NUnit.Framework;
using OpenQA.Selenium;

namespace UnitTest1
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

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver = null;
        }
        
        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl(steamUrl);
            Assert.Pass();
        }
    }
}