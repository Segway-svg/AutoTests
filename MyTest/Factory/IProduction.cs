using OpenQA.Selenium;

namespace MyTest.Factory;

public interface IProduction
{
    WebDriver Release(string language);
}