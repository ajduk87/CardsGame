using CardsGameServer.DomainLayer.Entities.GamesEntities;
using System.Collections.Generic;
using System.Data;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IGameStepService
    {
        void InsertSteps(IDbConnection connection, IEnumerable<GameStep> gameSteps, IDbTransaction transaction = null);
    }
}