using CardsGameServer.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IShiffleService
    {
        List<Card> Shiffle(IPile pile);
    }
}
