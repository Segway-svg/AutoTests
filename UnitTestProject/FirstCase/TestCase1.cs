using NUnit.Framework;

namespace UnitTestProject.FirstCase
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Driver.GetInstance();
        }

        [Test]
        public void OpenSteamTest()
        {
            MainPage mainPage = new MainPage();
            
            Assert.True(mainPage.OpenSteam(), "mainPage.OpenSteam()");
            
            Assert.True(mainPage.ClickAboutButton(), "mainPage.ClickAboutButton()");
            
            Assert.True(mainPage.ClickStoreButton(), "mainPage.ClickStoreButton()");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
        }
    }
}