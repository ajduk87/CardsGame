using CardsGameServer.DomainLayer.Entities.ValueObjects.GameProgress;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class GameProgress : Entity
    {
        public Name GameName { get; set; }
        public IsInProgress IsInProgress { get; set; }
    }
}