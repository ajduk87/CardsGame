using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Dtoes.Player;
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
        private readonly IShiffleService shiffleService;

        public PlayerService(ITableService tableService, IShiffleService shiffleService)
        {
            this.playerRepository = Factory.Create<IPlayerRepository>();

            this.tableService = tableService;
            this.shiffleService = shiffleService;
        }

        public int InsertPlayer(IDbConnection connection, Player player, IDbTransaction transaction = null) =>
            this.playerRepository.Insert(connection, player, transaction);

        public DrawStatusDto SelectDrawStatus(IDbConnection connection, int id, IDbTransaction transaction = null)
        {
            return this.playerRepository.SelectDrawStatus(connection, id, transaction);
        }

        public void DrawCard(IDbConnection connection, Player player, IDbTransaction transaction = null)
        {
            Card newTopCard = player.PlayingPile.GetCardFromTheTop();
            player.TopCard = newTopCard;
            this.playerRepository.Update(connection, player, transaction);
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
                Card topCard = player.PlayingPile.GetCardFromTheTop();
                GameStep gameStep = new GameStep
                {
                    PlayerId = player.Id,
                    IsStepWinner = new IsStepWinner(false),
                    CardValue = topCard.Value,
                    CardSuit = new CardSuit(topCard.Suit),
                    CardsLeft = player.PlayingPile.Count()
                };
                gamesteps.Add(gameStep);
                player.TopCard = new Card(new CardValue(topCard.Value), topCard.Suit);
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

        public void ShuffleCards(IDbConnection connection, IEnumerable<Player> players, IDbTransaction transaction = null) =>
            players.ForEach(player =>
                                {
                                    if (player.PlayingPile.Cards.Count() == 0)
                                    {
                                        player.PlayingPile = new PlayingPile(player.DiscardPile.Cards);
                                        player.DiscardPile = new DiscardPile();
                                        List<Card> shuffledCards = this.shiffleService.Shiffle(player.PlayingPile);
                                        player.PlayingPile = new PlayingPile(shuffledCards);
                                        this.playerRepository.Update(connection, player, transaction);
                                    }
                                });

    }
}
