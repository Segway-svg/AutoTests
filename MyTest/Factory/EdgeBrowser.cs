namespace MyTest.Factory;

public class EdgeBrowser : IBrowser
{
    public IProduction Create()
    {
        return new Edge();
    }
}