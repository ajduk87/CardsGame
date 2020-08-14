using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientControllerLibrary.Urls
{
    public class ConfigurationUrls : Urls
    {
        public string Configuration { get; }

        public ConfigurationUrls()
        {
            this.Configuration = $"{ServiceConfigurationIpAddress}/api/configuration";
        }
    }
}
