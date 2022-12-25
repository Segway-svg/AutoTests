namespace MyTest.Factory;

public class ChromeBrowser : IBrowser
{
    public IProduction Create()
    { 
        return new Chrome();
    }
}