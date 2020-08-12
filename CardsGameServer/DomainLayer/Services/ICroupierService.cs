using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public interface ICroupierService
    {
        IEnumerable<Player> SplitDeck(List<Card> cards, IEnumerable<Player> players);
        void CollectCardsForThisRoundFromPlayers(IEnumerable<Player> players);
    }
}
