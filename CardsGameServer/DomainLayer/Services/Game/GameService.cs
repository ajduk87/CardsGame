using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Extensions;
using CardsGameServer.DomainLayer.Repositories;
using RepositoryFactory;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CardsGameServer.DomainLayer.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly IGameProgressRepository gameProgressRepository;

        public GameService()
        {
            this.gameRepository = Factory.Create<IGameRepository>();
            this.gameProgressRepository = Factory.Create<IGameProgressRepository>();
        }

        public void InsertGame(IDbConnection connection, IEnumerable<Game> games, IDbTransaction transaction = null) =>
            games.ForEach(game =>
                                   this.gameRepository.Insert(connection, game, transaction));


        public void UpdateGame(IDbConnection connection, Game game, IDbTransaction transaction = null) =>
            this.gameRepository.Update(connection, game, transaction);

        public bool IsGameOver(IEnumerable<GameStep> gameSteps)
        {
            return gameSteps.Count(gameStep => gameStep.CardsLeft > 0) == 1;
        }

        public void Terminate(IDbConnection connection, Player winner, IDbTransaction transaction = null)
        {
            Game game = this.gameRepository.SelectLastestGameByPlayerId(connection, winner.Id, transaction);
            this.gameProgressRepository.UpdateStatus(connection, game.Name, false, transaction);
        }

    }
}