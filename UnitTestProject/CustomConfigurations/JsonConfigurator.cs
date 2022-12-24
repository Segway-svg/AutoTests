using Microsoft.Extensions.Configuration;
using UnitTestProject.CustomConfigurations.Configs;

namespace UnitTestProject.CustomConfigurations
{
    public static class JsonConfigurator
    {
        public static ConfigurationDataConfig GetConfigurationData()
        {
            IConfigurationSection configurationData = 
                GetConfigurationConfigDataRoot().GetSection(nameof(ConfigurationDataConfig));
            return configurationData.Get<ConfigurationDataConfig>();
        }
        
        public static TestDataConfig GetTestData()
        {
            IConfigurationSection testData = 
                GetConfigurationTestDataRoot().GetSection(nameof(TestDataConfig));
            return testData.Get<TestDataConfig>();
        }

        private static IConfigurationRoot GetConfigurationConfigDataRoot()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("config.json")
                .Build();
            return config;
        }
        
        private static IConfigurationRoot GetConfigurationTestDataRoot()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("testData.json")
                .Build();
            return config;
        }
    }
}