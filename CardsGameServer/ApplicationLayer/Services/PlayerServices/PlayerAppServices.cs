using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using CardsGameServer.DomainLayer.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Services.PlayerServices
{
    public class PlayerAppServices : BaseAppService, IPlayerAppServices
    {
        private readonly IPlayerService playerService;
        private readonly IScoreService scoreService;

        public PlayerAppServices(IPlayerService playerService, IScoreService scoreService)
        {
            this.playerService = playerService;
            this.scoreService = scoreService;
        }

        public void EnterPlayer(PlayerDto playerDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                Player player = this.dtoToEntityMapper.Map<PlayerDto, Player>(playerDto);
                int playerId = this.playerService.InsertPlayer(connection, player);
                Score score = new Score
                {
                    Id = new Id(playerId),
                    NumberOfWins = new NumberOfWins(0)
                };
                this.scoreService.Insert(connection, score);
            }
        }
    }
}
