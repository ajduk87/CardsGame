using CardsGameServer.DomainLayer.Entities.GamesEntities;
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

        public GameService()
        {
            this.gameRepository = Factory.Create<IGameRepository>();
        }

        public void InsertGame(IDbConnection connection, IEnumerable<Game> games, IDbTransaction transaction = null) =>
            games.ForEach(game =>
                                   this.gameRepository.Insert(connection, game, transaction));


        public void UpdateGame(IDbConnection connection, Game game, IDbTransaction transaction = null) =>
            this.gameRepository.Update(connection, game, transaction);
    }
}