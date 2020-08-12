using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public interface IPile
    {
        List<Card> Cards { get; }
    }
}