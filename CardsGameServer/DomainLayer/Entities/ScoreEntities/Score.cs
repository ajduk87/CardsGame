using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.ScoreEntities
{
    public class Score : Entity
    {
        public Id PlayerId { get; set; }
        public NumberOfWins NumberOfWins { get; set; }
    }
}