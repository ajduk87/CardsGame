using CardsGameServer.DomainLayer.Entities.GamesEntities;
using RepositoryFactory;
using System.Data;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IGameProgressRepository : IRepository
    {
        void Insert(IDbConnection connection, GameProgress gameProgress, IDbTransaction transaction = null);
    }
}