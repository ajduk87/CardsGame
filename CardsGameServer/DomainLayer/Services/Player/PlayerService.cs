using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Extensions;
using CardsGameServer.DomainLayer.Repositories;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        private readonly ITableService tableService;

        public PlayerService(ITableService tableService)
        {
            this.playerRepository = Factory.Create<IPlayerRepository>();

            this.tableService = tableService;
        }

        public void SetupCards(IDbConnection connection, IEnumerable<Player> players, IDbTransaction transaction = null) =>
            players.ForEach(player =>
            {
                this.playerRepository.Update(connection, player, transaction);
            });

        public void SetCardsToWinner(IDbConnection connection, Player winner, IDbTransaction transaction = null) =>
            this.playerRepository.Update(connection, winner, transaction);

        public IEnumerable<GameStep> StartTheGame(IEnumerable<Player> players)
        {
            List<GameStep> gamesteps = new List<GameStep>();

            players.ForEach(player =>
            {
                GameStep gameStep = new GameStep
                {
                    PlayerId = player.Id,
                    IsStepWinner = new IsStepWinner(false),
                    CardValue = new CardValue(),
                    CardsLeft = player.PlayingPile.Count()
                };
                gamesteps.Add(gameStep);
            });

            return gamesteps;
        }


        public Player PickRoundWinner(IEnumerable<Player> allplayers, IEnumerable<GameStep> gameSteps)
        {
            int winnerId = gameSteps.Single(gameStep => gameStep.IsStepWinner == true).PlayerId;
            Player winner = allplayers.Where(player => player.Id == winnerId).Single();
            List<Card> winningCards = this.tableService.GetCardsFromTable();
            winner.DiscardPile.AddCardsToPile(winningCards);

            return winner;
        }
    }
}
