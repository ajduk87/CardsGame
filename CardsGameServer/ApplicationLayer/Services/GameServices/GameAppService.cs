using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGameServer.ApplicationLayer.Services.GameServices
{
    public class GameAppService : BaseAppService, IGameAppService
    {
        private readonly IGameService gameService;
        private readonly IGameProgressService gameProgressService;

        public GameAppService(IGameService gameService, IGameProgressService gameProgressService)
        {
            this.gameService = gameService;
            this.gameProgressService = gameProgressService;
        }

        public void MakeNewGame(IEnumerable<GameDto> gameDtoes)
        {
            GameProgress gameProgress = this.dtoToEntityMapper.Map<GameDto, GameProgress>(gameDtoes.ToList().First());
            IEnumerable<Game> games = this.dtoToEntityMapper.MapList<IEnumerable<GameDto>, IEnumerable<Game>>(gameDtoes);

            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        this.gameProgressService.InsertProgress(connection, gameProgress, transaction);
                        this.gameService.InsertGame(connection, games, transaction);
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

        public void ChangeExisitngGame(GameDto gameDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                Game game = this.dtoToEntityMapper.Map<GameDto, Game>(gameDto);
                this.gameService.UpdateGame(connection, game);
            }
        }

        public void ProcessRound(GameRoundProcessDto GameRoundProcessDto)
        {
        }
    }
}