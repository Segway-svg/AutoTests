using System;
using System.Threading;
using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class TopGamePage
    {
        private readonly By _topGameNameLocator = By.XPath("//*[@id='appHubAppName']");
        private readonly By _topGamePriceLocator = By.XPath("//*[@class='game_purchase_action_bg']//div");
        private readonly By _topGameDiscountPriceLocator = By.XPath("//*[@class='game_purchase_action']" +
                                                                    "//div[@class='discount_final_price']");
        private readonly By _topGameReleaseDateLocator = By.XPath("//*[@id='game_highlights']" +
                                                                  "//div[@class='date']");

        public bool GetTopGameInfo()
        {
            Thread.Sleep(5000);
            
            IWebElement topGameName = Driver.GetInstance().FindElement(_topGameNameLocator);
            TopGameInfo.TopGameName = topGameName.Text;
            
            IWebElement topGamePrice = Driver.GetInstance().FindElement(_topGamePriceLocator);
            if (Driver.GetInstance().FindElement(_topGamePriceLocator).GetAttribute("class").Contains("discount"))
            {
                topGamePrice = Driver.GetInstance().FindElement(_topGameDiscountPriceLocator);
                TopGameInfo.TopGamePrice = topGamePrice.Text;

            }
            else
            {
                TopGameInfo.TopGamePrice = topGamePrice.Text;
            }

            IWebElement topGameReleaseDate = Driver.GetInstance().FindElement(_topGameReleaseDateLocator);
            TopGameInfo.TopGameReleaseDate = topGameReleaseDate.Text;
            return true;
        }

        public bool CompareTopGameInfoFromDifferentSources()
        {
            if (TopGameInfo.TopGameName == TopGameInfo.FromSalesLeadersTopGameName &&
                TopGameInfo.TopGamePrice == TopGameInfo.FromSalesLeadersTopGamePrice &&
                TopGameInfo.TopGameReleaseDate == TopGameInfo.FromSalesLeadersTopGameReleaseDate)
            {
                return true;
            }

            return false;
        }
    }
}