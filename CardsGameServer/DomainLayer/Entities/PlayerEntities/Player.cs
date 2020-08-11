using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.PlayerEntities
{
    public class Player : Entity
    {
        public Id Id { get; set; }
        public Name Name { get; set; }
        public NumberOfWins NumberOfWins { get; set; }
    }
}