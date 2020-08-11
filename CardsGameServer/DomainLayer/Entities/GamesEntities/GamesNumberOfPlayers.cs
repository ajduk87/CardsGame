using CardsGameServer.DomainLayer.Entities.ValueObjects.GamesNumberOfPlayers;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class GamesNumberOfPlayers : Entity
    {
        public Id Id { get; set; }
        public Id GameId { get; set; }
        public NumberOfPlayers NumberOfPlayers { get; set; }
    }
}