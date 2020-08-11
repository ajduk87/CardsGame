using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class GamesGameStep : Entity
    {
        public Id GameId { get; set; }
        public Id GameStepId { get; set; }
    }
}