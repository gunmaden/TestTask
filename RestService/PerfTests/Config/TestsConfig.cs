using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace PerfTests.Config
{
    public class TestsConfig
    {
        public static ConfigModel GetConfig()
        {
            var confPath = TestContext.CurrentContext.WorkDirectory;
            var config = new ConfigurationBuilder()
                .SetBasePath(confPath)
                .AddJsonFile("Config.json", false, false)
                .Build()
                .Get<ConfigModel>();

            return config;
        }
    }
}