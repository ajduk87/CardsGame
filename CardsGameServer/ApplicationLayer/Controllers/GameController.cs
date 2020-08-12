using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Models;
using CardsGameServer.ApplicationLayer.Services.GameServices;
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
    public class GameController : BaseController
    {

        private readonly IGameAppService gameAppService;

        public GameController(IGameAppService gameAppService)
        {
            this.gameAppService = gameAppService;
        }

        [HttpPost]
        [Route("api/newgame")]
        [ValidateModelStateFilter]
        public HttpResponseMessage MakeNewGame(IEnumerable<GameCreateModel> gameCreateModels)
        {
            IEnumerable<GameDto> gameDtoes = this.mapper.Map< IEnumerable<GameCreateModel>, IEnumerable<GameDto>>(gameCreateModels);
            this.gameAppService.MakeNewGame(gameDtoes);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/updategame")]
        [ValidateModelStateFilter]
        public HttpResponseMessage ChangeExisitngGame(GameUpdateModel gameUpdateModel)
        {
            GameDto gameDto = this.mapper.Map<GameUpdateModel, GameDto>(gameUpdateModel);
            this.gameAppService.ChangeExisitngGame(gameDto);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/processround")]
        //[ValidateModelStateFilter]
        public HttpResponseMessage GameRoundProcess(IEnumerable<PlayerStatusModel> playerStatusModels)
        {
            IEnumerable<PlayerStatusDto> playerStatusDtoes = this.mapper.Map<IEnumerable<PlayerStatusModel>, IEnumerable<PlayerStatusDto>>(playerStatusModels);
            this.gameAppService.ProcessRound(playerStatusDtoes);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
