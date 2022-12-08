using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTest1
{
    public class Tests
    {
        private IWebDriver _driver;
        private string _steamUrl;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver("C:\\Users\\tukat\\RiderProjects\\TestProject4\\" +
                                       "TestProject4\\bin\\Debug\\net5.0\\chromedriver.exe");
            _steamUrl = "https://store.steampowered.com/";
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
            Console.WriteLine(_driver.Title);
            _driver.Navigate().GoToUrl(_steamUrl);
            Assert.Pass();
        }
    }
}