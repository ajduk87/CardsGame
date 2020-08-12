using CardsGameServerQuery.Dtoes;
using CardsGameServerQuery.Repositories.Game;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardsGameServerQuery.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameDtoRepository gameDtoRepository;

        public GameController()
        {
            this.gameDtoRepository = new GameDtoRepository();
        }

        [HttpGet]
        [Route("api/gamebyid/{id}")]
        public GameDto GetGameById(int id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                try
                {
                    GameDto gameDtoes = this.gameDtoRepository.SelectById(connection, id);

                    return gameDtoes;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return new GameDto();
                }

            }
        }

        [HttpGet]
        [Route("api/gamebyname/{name}")]
        public IEnumerable<GameDto> GetGameByName(string name)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                try
                {
                    IEnumerable<GameDto> gameDtoes = this.gameDtoRepository.SelectByName(connection, name);

                    return gameDtoes;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return new List<GameDto>();
                }

            }
        }

        [HttpGet]
        [Route("api/getcards/{gamename}")]
        public IEnumerable<PlayerStatusDto> GameRoundProcess(string gamename)
        {
            return new List<PlayerStatusDto>();
        }
    }
}
