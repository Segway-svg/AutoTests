using System;
using NUnit.Framework;
using UnitTestProject.CommonEntities;

namespace UnitTestProject.FirstCase
{
    public class TestCase1
    {
        [SetUp]
        public void Setup()
        {
            Driver.GetInstance();
        }

        [Test]
        public void FirstCaseTests()
        {
            Assert.True(SteamOpener.OpenSteam(), "SteamOpener.OpenSteam()");

            FirstTestCaseMainPage firstTestCaseMainPage = new FirstTestCaseMainPage();
            Assert.True(firstTestCaseMainPage.ClickAboutButton(), "mainPage.ClickAboutButton()");

            Tuple<int, int> stats = firstTestCaseMainPage.CompareNumberOfPlayers();
            Assert.AreEqual(stats.Item1, stats.Item2);

            AboutPage aboutPage = new AboutPage();
            Assert.True(aboutPage.ClickStoreButton(), "mainPage.ClickStoreButton()");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.GetInstance().Quit();
        }
    }
}