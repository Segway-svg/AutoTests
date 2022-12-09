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
        
        [TearDown]
        public void TearDown()
        {
            var driver = Driver.GetInstance();
            driver.Quit();
        }
        
        [Test]
        public void OpenSteamTest()
        {
            MainPage mainPage = new MainPage();
            mainPage.OpenSteam();
            Assert.Pass();
            
            // TODO Кликнуть на кнопку ABOUT
            
            // TODO Сравнить числа игроков
            
            // TODO Перейти на страницу магазина
            
        }
    }
}