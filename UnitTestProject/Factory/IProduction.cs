using OpenQA.Selenium;

namespace UnitTestProject.Factory;

public interface IProduction
{
    WebDriver Release(string language);
}