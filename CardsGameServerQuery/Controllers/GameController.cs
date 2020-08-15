using CardsGameServerQuery.Dtoes;
using CardsGameServerQuery.Repositories.Game;
using CardsGameServerQuery.Repositories.Player;
using Npgsql;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CardsGameServerQuery.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameDtoRepository gameDtoRepository;
        private readonly IGameProgressDtoRepository gameProgressDtoRepository;
        private readonly IPlayerDtoRepository playerDtoRepository;
        private readonly IWinnerGetter winnerGetter;

        private string basePath = Path.Combine(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\CardsGameServer")), "Winner");
        private string winnerPath = string.Empty;

        public GameController()
        {
            this.gameDtoRepository = Factory.Create<IGameDtoRepository>();
            this.gameProgressDtoRepository = Factory.Create<IGameProgressDtoRepository>();
            this.playerDtoRepository = Factory.Create<IPlayerDtoRepository>();
            this.winnerGetter = Factory.Create<IWinnerGetter>();

            this.winnerPath = $"{this.basePath}\\winner.txt";
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
        [Route("api/getcardsandstatuses/{gamename}/{numberofplayers}")]
        public IEnumerable<PlayerStatusDto> GetCardsAndStatuses(string gamename, int numberofplayers)
        {
            IEnumerable<PlayerStatusDto> playerStatusDtoes = new List<PlayerStatusDto>();

            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                try
                {
                    playerStatusDtoes = this.playerDtoRepository.SelectPlayerStatusByGamename(connection, gamename, numberofplayers);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return new List<PlayerStatusDto>();
                }

            }

            return playerStatusDtoes;
        }


        [HttpGet]
        [Route("api/getcardsandstatusforplayer/{gamename}/{numberofplayers}/{id}")]
        public PlayerStatusDto GetCardsAndStatus(string gamename, int numberofplayers, int id)
        {
            IEnumerable<PlayerStatusDto> playerStatusDtoes = new List<PlayerStatusDto>();

            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                try
                {
                    playerStatusDtoes = this.playerDtoRepository.SelectPlayerStatusByGamename(connection, gamename, numberofplayers);
                    return playerStatusDtoes.Where(playerStatusDto => playerStatusDto.PlayerId == id).Single();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return new PlayerStatusDto();
                }

            }
        }

        [HttpGet]
        [Route("api/gameisinprogress/{gamename}")]
        public GameProgressDto GameIsInProgress(string gamename)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                try
                {
                    GameProgressDto gameProgressDto = this.gameProgressDtoRepository.SelectByName(connection, gamename);

                    return gameProgressDto;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return new GameProgressDto();
                }

            }
        }

        [HttpGet]
        [Route("api/gamewinner/{gamename}")]
        public GameWinnerDto GameWinner(string gamename)
        {
            return new GameWinnerDto
            {
                PlayerName = this.winnerGetter.GetWinnerName(winnerPath, gamename)
            };
        }
    }
}
