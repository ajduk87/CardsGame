using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects.ShuffledDeck
{
    public class Deck : ValueObject<Deck>
    {
        public string Content { get; }

        public Deck(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator Deck(string deck)
        {
            return new Deck(deck);
        }

        public static implicit operator string(Deck deck)
        {
            return deck.Content;
        }
    }
}
