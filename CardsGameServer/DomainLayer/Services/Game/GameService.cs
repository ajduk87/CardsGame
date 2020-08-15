using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Extensions;
using CardsGameServer.DomainLayer.Repositories;
using CardsGameServer.DomainLayer.Repositories.Game;
using RepositoryFactory;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CardsGameServer.DomainLayer.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly IGameProgressRepository gameProgressRepository;
        private readonly IWinnerSaver winnerSaver;

        private string basePath = Path.Combine(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\")), "Winner");
        private string winnerPath = string.Empty;

        public GameService()
        {
            this.gameRepository = Factory.Create<IGameRepository>();
            this.gameProgressRepository = Factory.Create<IGameProgressRepository>();
            this.winnerSaver = Factory.Create<IWinnerSaver>();

            this.winnerPath = $"{this.basePath}\\winner.txt";
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

        public void RecordWinner(IDbConnection connection, Player winner, IDbTransaction transaction = null)
        {
            Game game = this.gameRepository.SelectLastestGameByPlayerId(connection, winner.Id, transaction);
            this.winnerSaver.Save(this.winnerPath, $"{game.Name} {winner.Name}");
        }

    }
}