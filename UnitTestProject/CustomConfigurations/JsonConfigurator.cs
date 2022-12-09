using System;
using Microsoft.Extensions.Configuration;

namespace UnitTestProject.CustomConfigurations
{
    public static class JsonConfigurator
    {
        public static string GetSteamUrl()
        {
            IConfigurationSection configurationData = GetConfigurationRoot().GetSection(nameof(ConfigurationDataConfig));
            return configurationData.Get<ConfigurationDataConfig>().SteamUrl;
        }

        public static ConfigurationDataConfig GetConfigurationData()
        {
            IConfigurationSection configurationData = 
                GetConfigurationRoot().GetSection(nameof(ConfigurationDataConfig));
            return configurationData.Get<ConfigurationDataConfig>();
        }
        
        public static string MainPageUniqueLocator()
        {
            IConfigurationSection testData = GetConfigurationRoot().GetSection(nameof(TestDataConfig));
            return testData.Get<TestDataConfig>().MainPageUniqueLocator;
        }

        public static ConfigurationDataConfig GetTestData()
        {
            IConfigurationSection testData = 
                GetConfigurationRoot().GetSection(nameof(TestDataConfig));
            return testData.Get<ConfigurationDataConfig>();
        }
        
        public static IConfigurationRoot GetConfigurationRoot()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
    }
}