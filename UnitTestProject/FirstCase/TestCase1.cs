using NUnit.Framework;
using UnitTestProject.CommonEntities;
using UnitTestProject.CustomConfigurations;
using UnitTestProject.FirstCase.PageObjects;

namespace UnitTestProject.FirstCase
{
    public class TestCase1
    {
        [SetUp]
        public void Setup()
        {
            Driver.ChooseLanguage(JsonConfigurator.GetConfigurationData().SecondCaseLanguage);
            Driver.GetInstance();
            Driver.OpenSteam();
        }

        [Test]
        public void FirstCaseTests()
        {
            MainPage mainPage = new MainPage();
            Assert.True(mainPage.IsMainPageOpened());

            HeaderMenu headerMenu = new HeaderMenu();
            headerMenu.ClickAboutButton();

            AboutPage aboutPage = new AboutPage();
            Assert.True(aboutPage.IsAboutPageOpened());

            int peakCount = aboutPage.GetPeakCountOfPlayers();
            int onlineCount = aboutPage.GetOnlineCountOfPlayers();
            Assert.Greater(peakCount, onlineCount);

            headerMenu.ClickStoreButton();
            Assert.True(mainPage.IsMainPageOpened());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
            Driver.MakeNullable();
        }
    }
}