using CardsGameServer.DomainLayer.Entities.GamesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IEvaulationService
    {
        IEnumerable<GameStep> Evaulate(IEnumerable<GameStep> gameSteps);
    }
}
