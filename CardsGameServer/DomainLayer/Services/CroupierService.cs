using CardsGameServer.ApplicationLayer.Extensions;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public class CroupierService : ICroupierService
    {
        private readonly ITableService tableService;

        public CroupierService(ITableService tableService)
        {
            this.tableService = tableService;
        }

        public IEnumerable<Player> SplitDeck(List<Card> cards, IEnumerable<Player> players)
        {
            int waitingPlayersNumber = players.ToList().Count;

            players.ForEach(player =>
                          {
                              List<Card> playingCards = cards.GetRange(0, cards.Count / waitingPlayersNumber);
                              cards.RemoveRange(0, cards.Count / waitingPlayersNumber);
                              waitingPlayersNumber--;
                              player.PlayingPile = new PlayingPile(playingCards);
                              player.DiscardPile = new DiscardPile();
                              player.TopCard = new Card();
                          });

            return players;
        }

        public void CollectCardsForThisRoundFromPlayers(IEnumerable<Player> players)
        {
            List<Card> cardsForTable = new List<Card>();
            players.ForEach(player => cardsForTable.Add(player.TopCard));
            this.tableService.PutOnTable(cardsForTable);
        }
    }
}
