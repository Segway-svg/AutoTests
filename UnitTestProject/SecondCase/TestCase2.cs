using NUnit.Framework;
using SteamHw.CommonEntities;
using SteamHw.CustomConfigurations;
using SteamHw.SecondCase.PageObjects;

namespace SteamHw.SecondCase
{
    public class TestCase2
    {
        [SetUp]
        public void Setup()
        {
            Driver.ChooseLanguage(JsonConfigurator.GetConfigurationData().FirstCaseLanguage);
            Driver.GetInstance();
            Driver.OpenSteam();
        }

        [Test]
        public void SecondCaseTests()
        {
            MainPage mainPage = new MainPage();
            Assert.True(mainPage.IsMainPageOpened());
            mainPage.PerformSalesLeadersSubMenu();
            mainPage.ClickSalesLeadersButton();

            SalesLeadersPage salesLeadersPage = new SalesLeadersPage(); 
            Assert.True(salesLeadersPage.IsSalesLeadersPageOpened());
            salesLeadersPage.ClickWatchMoreButton();

            AllSalesLeadersPage allSalesLeadersPage = new AllSalesLeadersPage();
            Assert.True(allSalesLeadersPage.IsAllSalesLeadersPageOpened());
            
            allSalesLeadersPage.ClickOsCheckBox();
            Assert.True(allSalesLeadersPage.IsOsCheckBoxChecked());
            
            allSalesLeadersPage.ClickGenreCheckBox();
            Assert.True(allSalesLeadersPage.IsGenreCheckBoxChecked());
            
            allSalesLeadersPage.ClickCountOfPLayersMenuButton();
            
            allSalesLeadersPage.ClickCountOfPlayersCheckbox();
            Assert.True(allSalesLeadersPage.IsCountOfPlayersCheckBoxChecked());
            
            allSalesLeadersPage.PerformTopGameInfo();
            
            TopGameInfo topGameInfoFromList = allSalesLeadersPage.GetTopGameInfo();
            
            allSalesLeadersPage.ClickTopGameButton();

            TopGamePage topGamePage = new TopGamePage();
            Assert.True(topGamePage.IsTopGameOpened());
            
            TopGameInfo topGameInfoFromPage = topGamePage.GetTopGameInfo();
            Assert.True(topGamePage.CompareTopGameInfoFromDifferentSources(topGameInfoFromList, topGameInfoFromPage));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
            Driver.MakeNullable();
        }
    }
}