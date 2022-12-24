namespace UnitTestProject.Factory;

public class ChromeBrowser : IBrowser
{
    public IProduction Create()
    { 
        return new Chrome();
    }
}