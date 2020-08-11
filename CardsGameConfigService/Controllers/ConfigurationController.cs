using CardsGameConfigService.Models;
using CardsGameConfigService.Serialization;
using CardsGameConfigService.Validation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace CardsGameConfigService.Controllers
{
    public class ConfigurationController : ApiController
    {
        private string basePath = Path.Combine(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\")), "Configuration");
        private string configPath = string.Empty;
        private readonly IJsonSerializer jsonSerializer;

        public ConfigurationController(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
            this.configPath = $"{this.basePath}\\configs.json";
        }

        private void DeleteOldContent()
        {
            List<string> oldcontent = File.ReadAllLines(this.configPath).ToList();
            oldcontent.Clear();
            File.WriteAllLines(this.configPath, oldcontent.ToArray());
        }

        private void UpdateWithNewContent(PlayerNumberUpdateModel playerNumberUpdateModel)
        {
            string newcontent = this.jsonSerializer.Serialize(playerNumberUpdateModel);
            File.WriteAllText(this.configPath, newcontent);
        }

        private void WriteNewContent(PlayerNumberCreateModel playerNumberCreateModel)
        {
            string content = "{  numberOfPlayers: " + this.jsonSerializer.Serialize(playerNumberCreateModel.NumberOfPlayers) + " }";
            File.WriteAllText(this.configPath, content);
        }

        [HttpPost]
        [Route("api/configuration")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Update(PlayerNumberCreateModel playerNumberCreateModel)
        {
            WriteNewContent(playerNumberCreateModel);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/configuration")]
        [ValidateModelStateFilter]
        public HttpResponseMessage Update(PlayerNumberUpdateModel playerNumberUpdateModel)
        {
            DeleteOldContent();
            UpdateWithNewContent(playerNumberUpdateModel);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}