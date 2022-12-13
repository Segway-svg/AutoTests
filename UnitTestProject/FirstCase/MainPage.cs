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
            List<string> strings = new List<string>();
            try
            {
                strings.Add(Driver.GetInstance().FindElement(_statsPeakOnlineLocator).Text);
                strings.Add(Driver.GetInstance().FindElement(_statsOnlineNowLocator).Text);
            }
            catch
            {
                return Tuple.Create(0, 0);
            }
            
            List<string> counters = new List<string>();
            
            for (int i = 0; i < strings.Count; i++)
            {
                string[] strArr = strings[i].Split("\n");
                for (int j = 0; j < strArr.Length; j++)
                {
                    if (strArr.Contains(","))
                    {
                        counters.Add(strArr[j]);
                    }
                }
            }

            int peakCount = int.Parse(counters[0].Replace(",", ""));
            int nowCount = int.Parse(counters[1].Replace(",", ""));

            return Tuple.Create(peakCount, nowCount);
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