using System;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace UnitTestProject.FirstCase
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Driver.GetInstance();
        }

        [Test]
        public void OpenSteamTest()
        {
            MainPage mainPage = new MainPage();
            
            Assert.True(mainPage.OpenSteam(), "mainPage.OpenSteam()");
            
            Assert.True(mainPage.ClickAboutButton(), "mainPage.ClickAboutButton()");
            
            Tuple<int, int> stats = mainPage.CompareNumberOfPlayers();
            Assert.AreEqual(stats.Item1, stats.Item2);

            Assert.True(mainPage.ClickStoreButton(), "mainPage.ClickStoreButton()");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
        }
    }
}