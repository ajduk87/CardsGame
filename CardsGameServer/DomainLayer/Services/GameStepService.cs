using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using CardsGameServer.DomainLayer.Extensions;
using CardsGameServer.DomainLayer.Repositories;
using RepositoryFactory;
using System.Collections.Generic;
using System.Data;

namespace CardsGameServer.DomainLayer.Services
{
    public class GameStepService : IGameStepService
    {
        private readonly IGameStepRepository gameStepRepository;

        public GameStepService()
        {
            this.gameStepRepository = Factory.Create<IGameStepRepository>();
        }

        public IEnumerable<int> InsertSteps(IDbConnection connection, IEnumerable<GameStep> gameSteps, IDbTransaction transaction = null)
        {
            List<int> gameStepsIds = new List<int>();
            gameSteps.ForEach(gameStep =>
            {
                int gameStepsId = this.gameStepRepository.Insert(connection, gameStep, transaction);
                gameStepsIds.Add(gameStepsId);
            });
            return gameStepsIds;
        }

        public void ConnectStepsToGame(IDbConnection connection, IEnumerable<int> stepIds, Game game, IDbTransaction transaction = null) =>
            stepIds.ForEach(stepId =>
                                    {
                                        GamesGameStep gamesGameStep = new GamesGameStep
                                        {
                                            GameName = game.Name,
                                            GameStepId = new Id(stepId)
                                        };
                                        this.gameStepRepository.InsertChild(connection, gamesGameStep, transaction);
                                    });
    }
}