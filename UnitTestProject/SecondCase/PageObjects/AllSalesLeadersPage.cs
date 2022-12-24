using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SteamHw.CommonEntities;
using SteamHw.CustomConfigurations;

namespace SteamHw.SecondCase.PageObjects
{
    public class AllSalesLeadersPage
    {
        private readonly By _allSalesLeadersPageUniqueLocator = By.XPath("//*[contains(@id, 'results_filtered')]");

        private readonly By _osCheckBoxLocator = By.XPath("//*[@data-loc='Windows']");
        private readonly By _genreCheckBoxLocator = By.XPath("//*[@data-loc='Экшен']");
        private readonly By _countOfPlayersMenuLocator = By.XPath("//*[@data-collapse-name='category3']//div[@class='block_header']");
        private readonly By _countOfPlayersCheckBoxLocator = By.XPath("//*[@data-loc='Кооператив (LAN)']");
        
        private readonly By _topGameLocator = By.XPath("//*[@id='search_resultsRows']//a[1]");
        private readonly By _topGameNameLocator = By.XPath("//a[1]//span[@class='title']");
        
        private readonly By _topGamePriceFinderLocator = By.XPath("//a[1]//div[contains(@class, 'price_discount')]//div[2]");
        private readonly By _topGamePriceLocator = By.XPath("//a[1]//*[contains(@class, 'responsive_secondrow')]//div[2]");
        private readonly By _topGameDiscountPriceLocator = By.XPath("//a[1]//div[contains(@class, 'discounted')]//text()");
        
        private readonly By _topGameReleaseDateLocator = By.XPath("//a[1]//div[contains(@class, 'search_released')]");

        public bool IsAllSalesLeadersPageOpened()
        {
            Driver.GetInstance().FindElement(_allSalesLeadersPageUniqueLocator);
            return true;
        } 
        
        public void ClickOsCheckBox()
        {
            IWebElement osCheckBox = Driver.GetInstance().FindElement(_osCheckBoxLocator);
            osCheckBox.Click();
        }
        
        public bool IsOsCheckBoxChecked()
        {
            return Driver.GetInstance().FindElement(_osCheckBoxLocator).GetAttribute("class")
                .Contains(JsonConfigurator.GetTestData().IsChecked);
        }
        
        public void ClickGenreCheckBox()
        {
            IWebElement genreCheckBox = Driver.GetInstance().FindElement(_genreCheckBoxLocator);
            genreCheckBox.Click();
        }
        
        public bool IsGenreCheckBoxChecked()
        {
            return Driver.GetInstance().FindElement(_genreCheckBoxLocator).GetAttribute("class")
                .Contains(JsonConfigurator.GetTestData().IsChecked);
        }

        public void ClickCountOfPLayersMenuButton()
        {
            IWebElement countOfPlayersMenu = Driver.GetInstance().FindElement(_countOfPlayersMenuLocator);
            countOfPlayersMenu.Click();
        }
        
        public void ClickCountOfPlayersCheckbox()
        {
            IJavaScriptExecutor js = Driver.GetInstance();
            IWebElement countOfPlayersCheckBox = Driver.GetInstance().FindElement(_countOfPlayersCheckBoxLocator);
            js.ExecuteScript("arguments[0].scrollIntoView()", countOfPlayersCheckBox);
            countOfPlayersCheckBox.Click();
        }

        public bool IsCountOfPlayersCheckBoxChecked()
        {
            return Driver.GetInstance().FindElement(_countOfPlayersCheckBoxLocator).GetAttribute("class")
                .Contains(JsonConfigurator.GetTestData().IsChecked);
        }

        public void PerformTopGameInfo()
        {
            Actions action = new Actions(Driver.GetInstance());
            action.MoveToElement(Driver.GetInstance().FindElement(_topGameLocator));
            action.Perform();
        }
        
        public TopGameInfo GetTopGameInfo()
        {
            TopGameInfo topGameInfoFromList = new TopGameInfo();
            topGameInfoFromList.TopGameName = GetTextWithWait(_topGameNameLocator);
            
            if (Driver.GetInstance().FindElement(_topGamePriceFinderLocator).GetAttribute("class")
                .Contains(JsonConfigurator.GetTestData().IsDiscountPresent))
            {
                topGameInfoFromList.TopGamePrice = GetTextWithWait(_topGameDiscountPriceLocator);
            }
            topGameInfoFromList.TopGamePrice = GetTextWithWait(_topGamePriceLocator);
            
            topGameInfoFromList.TopGameReleaseDate = GetTextWithWait(_topGameReleaseDateLocator);
            
            return topGameInfoFromList;
        }

        private string GetTextWithWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(Driver.GetInstance(), TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            IWebElement topGameName = Driver.GetInstance().FindElement(locator);

            return topGameName.Text;
        }

        public void ClickTopGameButton()
        {
            IWebElement topGame = Driver.GetInstance().FindElement(_topGameLocator);
            topGame.Click();
        }
    }
}