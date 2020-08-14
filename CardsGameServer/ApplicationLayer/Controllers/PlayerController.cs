using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Models.Player;
using CardsGameServer.ApplicationLayer.Services.PlayerServices;
using CardsGameServer.ApplicationLayer.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardsGameServer.ApplicationLayer.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IPlayerAppServices playerAppServices;

        public PlayerController(IPlayerAppServices playerAppServices)
        {
            this.playerAppServices = playerAppServices;
        }

        [HttpPost]
        [Route("api/newplayer")]
        [ValidateModelStateFilter]
        public HttpResponseMessage CreatePlayer(PlayerCreateModel playerCreateModel)
        {
            PlayerDto playerDto = this.mapper.Map<PlayerCreateModel, PlayerDto>(playerCreateModel);

            this.playerAppServices.EnterPlayer(playerDto);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
