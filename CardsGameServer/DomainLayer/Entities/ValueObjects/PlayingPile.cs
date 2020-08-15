using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public class PlayingPile : ValueObject<PlayingPile>, IPile, ICardsCounter
    {
        public List<Card> Cards { get; }

        public PlayingPile()
        {
            this.Cards = new List<Card>();
        }

        public PlayingPile(List<Card> Cards)
        {
            this.Cards = Cards;
        }

        public CardsLeft Count()
        {
            return new CardsLeft(this.Cards.Count);
        }

        public Card GetCardFromTheTop()
        {
            Card firstOne = this.Cards.First();
            this.Cards.RemoveAt(0);
            return firstOne;
        }

        public override string ToString()
        {
            List<string> cardsRepresentation = new List<string>();
            this.Cards.ForEach(card => cardsRepresentation.Add(card.ToString()));


            return String.Join(",", cardsRepresentation);
        }
    }
}
