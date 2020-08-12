using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Entities.PlayerEntities
{
    public class Player : Entity
    {
        public Name Name { get; set; }
        public Card TopCard { get; set; }
        public PlayingPile PlayingPile { get; set; }
        public DiscardPile DiscardPile { get; set; }
    }
}