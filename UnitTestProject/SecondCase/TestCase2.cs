using NUnit.Framework;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class TestCase2
    {
        [SetUp]
        public void Setup()
        {
            Driver.GetInstance();
        }

        [Test]
        public void SecondCaseTests()
        {
            Assert.True(SteamOpener.OpenSteam(), "mainPage.OpenSteam()");
            
            SecondCaseTestMainPage secondCaseTestMainPage = new SecondCaseTestMainPage();
            Assert.True(secondCaseTestMainPage.ClickSalesLeadersButton(), "mainPage.ClickSalesLeadersButton()");
            
            SalesLeadersPage salesLeadersPage = new SalesLeadersPage();
            Assert.True(salesLeadersPage.ClickWatchMoreButton(), "mainPage.ClickWatchMoreButton()");
            
            AllSalesLeadersPage allSalesLeadersPage = new AllSalesLeadersPage();
            Assert.True(allSalesLeadersPage.ClickOsCheckBox(), "allSalesLeaders.ClickOsCheckBox()");
            Assert.True(allSalesLeadersPage.ClickGenreCheckBox(), "allSalesLeaders.ClickGenreCheckBox()");
            Assert.True(allSalesLeadersPage.ClickNumberOfPlayersCheckbox(), "allSalesLeaders.ClickNumberOfPlayersCheckbox()");
            Assert.True(allSalesLeadersPage.GetTopGameInfo());

            TopGamePage topGamePage = new TopGamePage();
            Assert.True(topGamePage.GetTopGameInfo());
            Assert.True(topGamePage.CompareTopGameInfoFromDifferentSources());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
        }
    }
}