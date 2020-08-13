﻿using CardsGameServerQuery.Dtoes;
using CardsGameServerQuery.Repositories.Game;
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
    public class GameController : BaseController
    {
        private readonly IGameDtoRepository gameDtoRepository;
        private readonly IPlayerDtoRepository playerDtoRepository;

        public GameController()
        {
            this.gameDtoRepository = Factory.Create<IGameDtoRepository>();
            this.playerDtoRepository = Factory.Create<IPlayerDtoRepository>();
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
        public IEnumerable<PlayerStatusDto> GameRoundProcess(string gamename, int numberofplayers)
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
    }
}
