using System;
using ApiClientProject.Client;

namespace PerfTests.Config
{
    public class ConfigModel
    {
        public Uri SiteUri { get; set; }
        public int SessionsCount { get; set; }
        public int WarmUpDurationInSeconds { get; set; }
        public int TestingDurationInSeconds { get; set; }

        public Configuration GetConfiguration()
        {
            var conf = new GlobalConfiguration
            {
                BasePath = SiteUri.ToString()
            };
            return conf;
        }
    }
}