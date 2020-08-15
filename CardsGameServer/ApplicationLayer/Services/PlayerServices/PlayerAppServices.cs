using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Dtoes.Player;
using CardsGameServer.ApplicationLayer.Extensions;
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
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Player player = this.dtoToEntityMapper.Map<PlayerDto, Player>(playerDto);
                        int playerId = this.playerService.InsertPlayer(connection, player);
                        Score score = new Score
                        {
                            PlayerId = new Id(playerId),
                            NumberOfWins = new NumberOfWins(0)
                        };
                        this.scoreService.Insert(connection, score);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }

                }
            }
        }


        public void DrawCards(IEnumerable<DrawCardDto> drawCardsDtoes)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach(DrawCardDto drawCardDto in drawCardsDtoes)
                        {
                            DrawStatusDto drawStatusDto = this.playerService.SelectDrawStatus(connection, drawCardDto.PlayerId, transaction);
                            Player player = this.dtoToEntityMapper.Map<DrawStatusDto, Player>(drawStatusDto);
                            this.playerService.DrawCard(connection, player, transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }

                }
            }
        }
    }
}
