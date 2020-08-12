using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class GamesGameStep : Entity
    {
        public Name GameName { get; set; }
        public Id GameStepId { get; set; }
    }
}