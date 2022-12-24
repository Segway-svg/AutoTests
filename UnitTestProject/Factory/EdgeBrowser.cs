using UnitTestProject.Factory;

namespace UnitTestProject.FirstCase.PageObjects;

public class EdgeBrowser : IBrowser
{
    public IProduction Create()
    {
        return new Edge();
    }
}