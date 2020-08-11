using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
