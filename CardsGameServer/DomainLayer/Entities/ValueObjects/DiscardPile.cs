using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public class DiscardPile : ValueObject<DiscardPile>, IPile, ICardsCounter
    {
        public List<Card> Cards { get; }

        public DiscardPile()
        {
            this.Cards = new List<Card>();
        }

        public DiscardPile(List<Card> Cards)
        {
            this.Cards = Cards;
        }

        public void AddCardsToPile(List<Card> cards) =>
            this.Cards.AddRange(cards);


        public CardsLeft Count()
        {
            return new CardsLeft(this.Cards.Count);
        }

        public override string ToString()
        {
            List<string> cardsRepresentation = new List<string>();
            this.Cards.ForEach(card => cardsRepresentation.Add(card.ToString()));


            return String.Join(",", cardsRepresentation);
        }
    }
}
