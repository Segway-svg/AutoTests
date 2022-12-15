using UnitTestProject.CustomConfigurations;

namespace UnitTestProject.CommonEntities
{
    public static class SteamOpener
    {
        public static bool OpenSteam()
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
    }
}