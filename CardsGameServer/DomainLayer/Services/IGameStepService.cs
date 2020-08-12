using CardsGameServer.DomainLayer.Entities.GamesEntities;
using System.Collections.Generic;
using System.Data;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IGameStepService
    {
        IEnumerable<int> InsertSteps(IDbConnection connection, IEnumerable<GameStep> gameSteps, IDbTransaction transaction = null);
        void ConnectStepsToGame(IDbConnection connection, IEnumerable<int> stepIds, Game game, IDbTransaction transaction = null);
    }
}