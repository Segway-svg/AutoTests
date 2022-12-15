using System.Threading;
using OpenQA.Selenium;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.SecondCase
{
    public class AllSalesLeaders
    {
        private readonly By _isCheckBoxLocator = By.XPath("//*[contains(@class, 'checked')]");
        private readonly By _osCheckBoxLocator = By.XPath("//*[@data-loc='Windows']");
        private readonly By _genreCheckBoxLocator = By.XPath("//*[@data-loc='Экшен']");
        private readonly By _countOfPlayersMenuLocator = By.XPath("//*[@id='additional_search_options']/div[5]/div[1]");
        private readonly By _countOfPlayersCheckBoxLocator = By.XPath("//*[@data-loc='Кооператив (LAN)']");
        
        public bool ClickOsCheckBox()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor js = Driver.GetInstance();
            IWebElement osCheckBox = Driver.GetInstance().FindElement(_osCheckBoxLocator);

            js.ExecuteScript("arguments[0].scrollIntoView()", osCheckBox);
            
            osCheckBox.Click();
            Thread.Sleep(5000);
            return true;
        }
        
        public bool ClickGenreCheckBox()
        {
            Thread.Sleep(5000);
            
            IJavaScriptExecutor js = Driver.GetInstance();
            IWebElement genreCheckBox = Driver.GetInstance().FindElement(_genreCheckBoxLocator);

            js.ExecuteScript("arguments[0].scrollIntoView()", genreCheckBox);
            
            genreCheckBox.Click();
            Thread.Sleep(5000);
            return true;
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
            return true;
        }

        public bool IsCheckBox()
        {
            return true;
        }
    }
}