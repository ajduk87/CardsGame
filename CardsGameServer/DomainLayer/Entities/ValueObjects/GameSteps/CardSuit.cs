using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps
{
    public class CardSuit : ValueObject<CardSuit>
    {
        public string Content { get; }

        public CardSuit(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator CardSuit(string cardSuit)
        {
            return new CardSuit(cardSuit);
        }

        public static implicit operator string(CardSuit cardSuit)
        {
            return cardSuit.Content;
        }
    }
}
