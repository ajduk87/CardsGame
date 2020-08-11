using CardsGameConfigService.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardsGameConfigService.Controllers
{
    public class ConfigurationController : ApiController
    {
        private readonly IJsonSerializer jsonSerializer;

        public ConfigurationController(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
        }
    }
}
