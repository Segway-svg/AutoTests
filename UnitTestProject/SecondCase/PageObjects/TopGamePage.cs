using OpenQA.Selenium;
using SteamHw.CommonEntities;

namespace SteamHw.SecondCase.PageObjects
{
    public class TopGamePage
    {
        private readonly By _topGamePageUniqueLocator = By.XPath("//*[contains(@id, 'game_area_purchase_')]");
        private readonly By _topGameNameLocator = By.XPath("//*[@id='appHubAppName']");
        private readonly By _topGamePriceLocator = By.XPath("//*[contains(@class, 'game_purchase_price')]");
        private readonly By _topGameDiscountPriceLocator = By.XPath("//*[@class='game_purchase_action']//div[@class='discount_final_price']");
        private readonly By _topGameReleaseDateLocator = By.XPath("//div[@class='date']");

        public bool IsTopGameOpened()
        {
            Driver.GetInstance().FindElement(_topGamePageUniqueLocator);
            return true;
        } 
        
        public TopGameInfo GetTopGameInfo()
        {
            TopGameInfo topGameInfoFromPage = new TopGameInfo();
            
            IWebElement topGameName = Driver.GetInstance().FindElement(_topGameNameLocator);
            topGameInfoFromPage.TopGameName = topGameName.Text;
            
            IWebElement topGamePrice = Driver.GetInstance().FindElement(_topGamePriceLocator);
            if (Driver.GetInstance().FindElement(_topGamePriceLocator).GetAttribute("class").Contains("discount"))
            {
                topGamePrice = Driver.GetInstance().FindElement(_topGameDiscountPriceLocator);
                topGameInfoFromPage.TopGamePrice = topGamePrice.Text;
            }
            else
            {
                topGameInfoFromPage.TopGamePrice = topGamePrice.Text;
            }

            IWebElement topGameReleaseDate = Driver.GetInstance().FindElement(_topGameReleaseDateLocator);
            topGameInfoFromPage.TopGameReleaseDate = topGameReleaseDate.Text;
            
            return topGameInfoFromPage;
        }

        public bool CompareTopGameInfoFromDifferentSources(TopGameInfo topGameInfo1, TopGameInfo topGameInfo2)
        {
            return topGameInfo1 == topGameInfo2;
        }
    }
}