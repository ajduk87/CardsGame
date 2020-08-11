using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery
{
    public class ConfigurationService : IConfigurationService
    {
        public List<Parameter> GetParameters()
        {
            using (StreamReader streamReader = new StreamReader("..\\..\\db.json"))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Parameter>>(json);
            }
        }
    }
}
