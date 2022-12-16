using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class AllSalesLeadersPage
    {
        private readonly string _isChecked = "checked";
        private readonly By _checkBoxLocator = By.XPath("//*[contains(@class, 'tab_filter_control_checkbox')]");
        
        private readonly By _osCheckBoxLocator = By.XPath("//*[@data-loc='Windows']");
        private readonly By _genreCheckBoxLocator = By.XPath("//*[@data-loc='Экшен']");
        private readonly By _countOfPlayersMenuLocator = By.XPath("//*[@id='additional_search_options']/div[5]/div[1]");
        private readonly By _countOfPlayersCheckBoxLocator = By.XPath("//*[@data-loc='Кооператив (LAN)']");
        
        private readonly By _topGameLocator = By.XPath("//*[@id='search_resultsRows']/a[1]");
        private readonly By _topGameNameLocator = By.XPath("//*[@id='search_resultsRows']" +
                                                           "//a[1]//span[@class='title']");
        private readonly By _topGamePriceLocator = By.XPath("//*[@id='search_resultsRows']" +
                                                            "//a[1]//div[contains(@class, 'search_price')]//div[2]");
        private readonly By _topGameReleaseDateLocator = By.XPath("//*[@id='search_resultsRows']" +
                                                           "//div[contains(@class, 'search_released')]");

        public bool ClickOsCheckBox()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor js = Driver.GetInstance();
            IWebElement osCheckBox = Driver.GetInstance().FindElement(_osCheckBoxLocator);

            js.ExecuteScript("arguments[0].scrollIntoView()", osCheckBox);
            
            osCheckBox.Click();
            Thread.Sleep(5000);

            if (Driver.GetInstance().FindElement(_osCheckBoxLocator).GetAttribute("class").Contains(_isChecked))
            {
                return true;
            }
            return false;
        }
        
        public bool ClickGenreCheckBox()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor js = Driver.GetInstance();
            IWebElement genreCheckBox = Driver.GetInstance().FindElement(_genreCheckBoxLocator);

            js.ExecuteScript("arguments[0].scrollIntoView()", genreCheckBox);
            
            genreCheckBox.Click();
            Thread.Sleep(5000);
            
            if (Driver.GetInstance().FindElement(_genreCheckBoxLocator).GetAttribute("class").Contains(_isChecked))
            {
                return true;
            }
            return false;
        }
        
        public bool ClickNumberOfPlayersCheckbox()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor js = Driver.GetInstance();
            IWebElement countOfPlayersMenu = Driver.GetInstance().FindElement(_countOfPlayersMenuLocator);

            js.ExecuteScript("arguments[0].scrollIntoView()", countOfPlayersMenu);
            
            countOfPlayersMenu.Click();
            Thread.Sleep(5000);
            
            IWebElement countOfPlayersCheckBox = Driver.GetInstance().FindElement(_countOfPlayersCheckBoxLocator);
            countOfPlayersCheckBox.Click();
            
            Thread.Sleep(5000);
            
            if (Driver.GetInstance().FindElement(_countOfPlayersCheckBoxLocator).GetAttribute("class").Contains(_isChecked))
            {
                return true;
            }
            return false;
        }

        public bool GetTopGameInfo()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor js = Driver.GetInstance();
            
            IWebElement topGameName = Driver.GetInstance().FindElement(_topGameNameLocator);
            js.ExecuteScript("arguments[0].scrollIntoView()", topGameName);
            TopGameInfo.FromSalesLeadersTopGameName = topGameName.Text;
            
            Thread.Sleep(5000);
            
            IWebElement topGamePrice = Driver.GetInstance().FindElement(_topGamePriceLocator);
            js.ExecuteScript("arguments[0].scrollIntoView()", topGamePrice);
            TopGameInfo.FromSalesLeadersTopGamePrice = topGamePrice.Text;

            Thread.Sleep(5000);
        
            IWebElement topGameReleaseDate = Driver.GetInstance().FindElement(_topGameReleaseDateLocator);
            js.ExecuteScript("arguments[0].scrollIntoView()", topGameReleaseDate);
            TopGameInfo.FromSalesLeadersTopGameReleaseDate = topGameReleaseDate.Text;

            Thread.Sleep(5000);

            IWebElement topGame = Driver.GetInstance().FindElement(_topGameLocator);
            topGame.Click();
            return true;
        }
    }
}