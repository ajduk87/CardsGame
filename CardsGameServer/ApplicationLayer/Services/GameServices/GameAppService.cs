using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
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
        private readonly ITableService tableService;
        private readonly IEvaulationService evaulationService;
        private readonly IPlayerService playerService;
        private readonly IScoreService scoreService;

        public GameAppService(IGameService gameService,
                              IGameProgressService gameProgressService,
                              IShiffleService shiffleService,
                              ICroupierService croupierService,
                              IGameStepService gameStepService,
                              IEvaulationService evaulationService,
                              IPlayerService playerService,
                              IScoreService scoreService)
        {
            this.gameService = gameService;
            this.gameProgressService = gameProgressService;
            this.shiffleService = shiffleService;
            this.croupierService = croupierService;
            this.gameStepService = gameStepService;
            this.evaulationService = evaulationService;
            this.playerService = playerService;
            this.scoreService = scoreService;
        }

        public void MakeNewGame(IEnumerable<GameDto> gameDtoes)
        {
            GameProgress gameProgress = this.dtoToEntityMapper.Map<GameDto, GameProgress>(gameDtoes.ToList().First());
            IEnumerable<Game> games = this.dtoToEntityMapper.MapList<IEnumerable<GameDto>, IEnumerable<Game>>(gameDtoes);
            IEnumerable<Player> players = this.dtoToEntityMapper.MapList<IEnumerable<GameDto>, IEnumerable<Player>>(gameDtoes);

            List<Card> shuffledCards = this.shiffleService.Shiffle(new NewPile());
            IEnumerable<Player> playersWithCards = this.croupierService.SplitDeck(shuffledCards, players);
            IEnumerable<GameStep> gameSteps = this.playerService.StartTheGame(playersWithCards);

            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        this.playerService.SetupCards(connection, playersWithCards, transaction);
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


        public void StartRound(IEnumerable<PlayerStatusDto> playerStatusDtoes)
        {
            IEnumerable<GameStep> gameSteps = this.dtoToEntityMapper.MapList<IEnumerable<PlayerStatusDto>, IEnumerable<GameStep>>(playerStatusDtoes);
            IEnumerable<Player> players = this.dtoToEntityMapper.MapList<IEnumerable<PlayerStatusDto>, IEnumerable<Player>>(playerStatusDtoes);

            this.croupierService.CollectCardsForThisRoundFromPlayers(players);

            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        this.playerService.SetupCards(connection, players, transaction);
                        this.gameStepService.InsertSteps(connection, gameSteps, transaction);
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

        public void ProcessRound(IEnumerable<PlayerStatusDto> playerStatusDtoes)
        {
            IEnumerable<GameStep> gameSteps = this.dtoToEntityMapper.MapList<IEnumerable<PlayerStatusDto>, IEnumerable<GameStep>>(playerStatusDtoes);
            IEnumerable<Player> players = this.dtoToEntityMapper.MapList<IEnumerable<PlayerStatusDto>, IEnumerable<Player>>(playerStatusDtoes);

            IEnumerable<GameStep> evaulatedGameSteps = this.evaulationService.Evaulate(gameSteps);
            if (evaulatedGameSteps.Any(step => step.IsStepWinner == true))
            {
                Player roundWinner = this.playerService.PickRoundWinner(players, evaulatedGameSteps);

                using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            this.playerService.SetCardsToWinner(connection, roundWinner);
                            this.gameStepService.UpdateSteps(connection, evaulatedGameSteps, transaction);

                            if (this.gameService.IsGameOver(evaulatedGameSteps))
                            {
                                Player winner = roundWinner;
                                this.gameService.Terminate(connection, winner, transaction);
                                this.scoreService.IncreaseScore(connection, winner, transaction);
                            }
                            else
                            {
                                this.playerService.ShuffleCards(connection, players, transaction);
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
}