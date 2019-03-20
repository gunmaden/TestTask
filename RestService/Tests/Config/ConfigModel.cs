using System;
using ApiClientProject.Client;

namespace Tests.Config
{
    public class ConfigModel
    {
        public Uri SiteUri { get; set; }

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