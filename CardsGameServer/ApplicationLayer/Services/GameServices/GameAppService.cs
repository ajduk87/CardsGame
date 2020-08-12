using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
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
        private readonly IShiffleService shiffleService;
        private readonly ICroupierService croupierService;
        private readonly IGameStepService gameStepService;

        public GameAppService(IGameService gameService,
                              IGameProgressService gameProgressService,
                              IShiffleService shiffleService,
                              ICroupierService croupierService,
                              IGameStepService gameStepService)
        {
            this.gameService = gameService;
            this.gameProgressService = gameProgressService;
            this.shiffleService = shiffleService;
            this.croupierService = croupierService;
            this.gameStepService = gameStepService;
        }

        public void MakeNewGame(IEnumerable<GameDto> gameDtoes)
        {
            GameProgress gameProgress = this.dtoToEntityMapper.Map<GameDto, GameProgress>(gameDtoes.ToList().First());
            IEnumerable<Game> games = this.dtoToEntityMapper.MapList<IEnumerable<GameDto>, IEnumerable<Game>>(gameDtoes);
            IEnumerable<Player> players = this.dtoToEntityMapper.MapList<IEnumerable<GameDto>, IEnumerable<Player>>(gameDtoes);

            List<Card> shuffledCards = this.shiffleService.Shiffle(new NewPile());
            IEnumerable<GameStep> gameSteps = this.croupierService.SplitDeck(shuffledCards, players);

            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        this.gameProgressService.InsertProgress(connection, gameProgress, transaction);
                        this.gameService.InsertGame(connection, games, transaction);
                        IEnumerable<int> gamestepsIds = this.gameStepService.InsertSteps(connection, gameSteps, transaction);
                        this.gameStepService.ConnectStepsToGame(connection, gamestepsIds, games.ToList().First());
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