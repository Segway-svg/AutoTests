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
            
            AllSalesLeaders allSalesLeaders = new AllSalesLeaders();
            Assert.True(allSalesLeaders.ClickOsCheckBox(), "allSalesLeaders.ClickOsCheckBox()");
            Assert.True(allSalesLeaders.ClickGenreCheckBox(), "allSalesLeaders.ClickGenreCheckBox()");
            Assert.True(allSalesLeaders.ClickNumberOfPlayersCheckbox(), "allSalesLeaders.ClickNumberOfPlayersCheckbox()");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
        }
    }
}