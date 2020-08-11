using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities
{
    public abstract class Entity : IEntity<Id>
    {
        public Id Id { get; set; }
    }
}