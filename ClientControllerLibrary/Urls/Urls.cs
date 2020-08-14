using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientControllerLibrary.Urls
{
    public abstract class Urls
    {
        protected readonly string ServerCommandIpAddress = "http://localhost:12346/";
        protected readonly string ServerQueryIpAddress = "http://localhost:12347/";
        protected readonly string ServiceConfigurationIpAddress = "http://localhost:12348/";
    }
}
