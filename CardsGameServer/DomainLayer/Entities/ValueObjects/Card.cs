using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public class Card : ValueObject<Card>
    {
        public CardValue Value { get; }
        public string Suit { get; }

        public Card(CardValue Value, string Suit)
        {
            this.Value = Value;
            this.Suit = Suit;
        }

        public bool IsGreater(Card otherCard)
        {
            return this.Value > otherCard.Value;
        }

        public bool IsEqual(Card otherCard)
        {
            if (this == null)
                return false;

            return this.Value == otherCard.Value;
        }

        //also it can be
        public override bool Equals(Card otherCard)
        {
            if (this == null)
                return false;

            return Equals(otherCard);
        }

        public override string ToString()
        {
            return $"{this.Value.Content} {this.Suit}";
        }
    }
}
