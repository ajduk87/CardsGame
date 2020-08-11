using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public class PlayingPile : ValueObject<PlayingPile>
    {
        public List<Card> Cards { get; }

        public PlayingPile(List<Card> Cards)
        {
            this.Cards = Cards;
        }
    }
}
