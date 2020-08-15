using CardsGameServer.DomainLayer.Entities.GamesEntities;
using RepositoryFactory;
using System.Data;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IGameRepository : IRepository
    {
        void Insert(IDbConnection connection, Entities.GamesEntities.Game game, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Entities.GamesEntities.Game game, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, int id, IDbTransaction transaction = null);
        Entities.GamesEntities.Game SelectLastestGameByPlayerId(IDbConnection connection, int id, IDbTransaction transaction = null);
    }
}