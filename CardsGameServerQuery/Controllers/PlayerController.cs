using CardsGameServerQuery.Dtoes;
using CardsGameServerQuery.Repositories.Player;
using Npgsql;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardsGameServerQuery.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IPlayerDtoRepository playerDtoRepository;

        public PlayerController()
        {
            this.playerDtoRepository = Factory.Create<IPlayerDtoRepository>();
        }

        [HttpGet]
        [Route("api/players")]
        public IEnumerable<PlayerDto> GetPlayers()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                try
                {
                    IEnumerable<PlayerDto> playersDtoes = this.playerDtoRepository.SelectAll(connection);

                    return playersDtoes;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return new List<PlayerDto>();
                }

            }
        }
    }
}
