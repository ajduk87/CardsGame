using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public class DiscardPile : ValueObject<DiscardPile>
    {
        public List<Card> Cards { get; }

        public DiscardPile(List<Card> Cards)
        {
            this.Cards = Cards;
        }
    }
}
