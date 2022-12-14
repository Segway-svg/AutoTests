using System;
using System.Collections.Generic;
using System.Drawing;
using AngleSharp.Text;
using OpenQA.Selenium;
using UnitTestProject.CustomConfigurations;

namespace UnitTestProject.FirstCase
{
    public class MainPage
    {
        private readonly By _aboutButtonLocator = By.XPath("//*[@id='global_header']" +
                                                           "//a[contains(text(), 'ABOUT')]");
        
        private readonly By _storeButtonLocator = By.XPath("//*[@id='global_header']" +
                                                           "//a[@data-tooltip-content='.submenu_store']");
                
        private readonly By _statsPeakOnlineLocator = By.XPath("//*[@id='about_greeting']" +
                                                               "/div[3]/div[1]");
        
        private readonly By _statsOnlineNowLocator = By.XPath("//*[@id='about_greeting']" +
                                                              "/div[3]/div[2]");
        
        public bool OpenSteam()
        {
            string steamUrl = JsonConfigurator.GetConfigurationData().SteamUrl;
            try
            {
                Driver.GetInstance().Navigate().GoToUrl(steamUrl);
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public bool ClickAboutButton()
        {
            IWebElement aboutButton;
            try
            {
                aboutButton = Driver.GetInstance().FindElement(_aboutButtonLocator);
            }
            catch
            {
                return false;
            }
            aboutButton.Click();
            return true;
        }

        public Tuple<int, int> CompareNumberOfPlayers()
        {
            string peakStr = Driver.GetInstance().FindElement(_statsPeakOnlineLocator).Text;
            string[] peakStrArr = peakStr.Split("\n");
            
            for (int i = 0; i < peakStrArr.Length; i++)
            {
                if (peakStrArr.Contains(","))
                {
                    peakStr = peakStrArr[i].Replace(",", "");
                }
            }
            
            string onlineStr = Driver.GetInstance().FindElement(_statsOnlineNowLocator).Text;
            string[] onlineStrArr = onlineStr.Split("\n");

            for (int i = 0; i < onlineStrArr.Length; i++)
            {
                if (onlineStrArr.Contains(","))
                {
                    onlineStr = onlineStrArr[i].Replace(",", "");
                }
            }

            if (int.TryParse(peakStr, out int peakNum) && int.TryParse(onlineStr, out int onlineNum))
            {
                return Tuple.Create(peakNum, onlineNum);
            }

            return Tuple.Create(0, 0);
        }
        
        public bool ClickStoreButton()
        {
            IWebElement storeButton;
            try
            {
                storeButton = Driver.GetInstance().FindElement(_storeButtonLocator);
            }
            catch
            {
                return false;
            }
            storeButton.Click();
            return true;
        }
    }
}