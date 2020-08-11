using CardsGameServer.ApplicationLayer.Dtoes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CardsGameServer.ApplicationLayer.Services.Configuration
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