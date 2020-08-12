using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Entities.PlayerEntities
{
    public class Player : Entity
    {
        public Name Name { get; set; }
        public NumberOfWins NumberOfWins { get; set; }
        public Card TopCard { get; set; }
        public IsStepWinner IsStepWinner { get; set; }
        public PlayingPile playingPile { get; set; }
        public DiscardPile discardPile { get; set; }
    }
}