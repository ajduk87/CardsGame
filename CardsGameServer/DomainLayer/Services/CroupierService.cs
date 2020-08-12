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

        private IEnumerable<GameStep> MakeGameSteps(IEnumerable<Player> players)
        {
            List<GameStep> gamesteps = new List<GameStep>();

            players.ForEach(player =>
                            {
                                GameStep gameStep = new GameStep
                                {
                                    PlayerId = player.Id,
                                    IsStepWinner = new IsStepWinner(false),
                                    CardValue = new CardValue(),
                                    CardsLeft = player.playingPile.Count(),
                                    PlayingPile = player.playingPile,
                                    DiscardPile = new DiscardPile()
                                };
                                gamesteps.Add(gameStep);
                            });

            return gamesteps;
        }


        public IEnumerable<GameStep> SplitDeck(List<Card> cards, IEnumerable<Player> players)
        {
            int waitingPlayersNumber = players.ToList().Count;

            players.ForEach(player =>
                          {
                              List<Card> playingCards = cards.GetRange(0, cards.Count / waitingPlayersNumber);
                              cards.RemoveRange(0, cards.Count / waitingPlayersNumber);
                              waitingPlayersNumber--;
                              player.playingPile = new PlayingPile(playingCards);
                          });
            IEnumerable<GameStep> gamesteps = MakeGameSteps(players);

            return gamesteps;
        }
    }
}
