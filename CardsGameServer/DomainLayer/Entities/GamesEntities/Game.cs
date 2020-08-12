using CardsGameServer.DomainLayer.Entities.ValueObjects.Games;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class Game : Entity
    {
        public Name Name { get; set; }
        public Id PlayerId { get; set; }
        public NumberOfSteps NumberOfSteps { get; set; }
        public IsWinner IsWinner { get; set; }
    }
}