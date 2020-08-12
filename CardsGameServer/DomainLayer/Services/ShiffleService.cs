using CardsGameServer.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public class ShiffleService : IShiffleService
    {
        public List<Card> Shiffle(IPile pile)
        {
            Card[] cards = pile.Cards.ToArray();
            Random r = new Random();

            for (int i = cards.Length - 1; i > 0; i--)
            {
                int j = r.Next(0, i + 1);

                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }

            return cards.ToList();
        }
    }
}
