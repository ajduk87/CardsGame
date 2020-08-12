using CardsGameServer.DomainLayer.Entities.GamesEntities;
using System.Data;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IGameProgressService
    {
        void InsertProgress(IDbConnection connection, GameProgress gameProgress, IDbTransaction transaction = null);
    }
}