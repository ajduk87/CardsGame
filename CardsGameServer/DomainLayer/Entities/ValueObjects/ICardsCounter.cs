using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public interface ICardsCounter
    {
        CardsLeft Count();
    }
}