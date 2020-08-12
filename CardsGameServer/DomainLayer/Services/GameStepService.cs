using CardsGameServer.ApplicationLayer.Extensions;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
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

        public void InsertSteps(IDbConnection connection, IEnumerable<GameStep> gameSteps, IDbTransaction transaction = null) =>
            gameSteps.ForEach(gameStep => this.gameStepRepository.Insert(connection, gameStep, transaction));
    }
}