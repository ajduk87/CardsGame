using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using RepositoryFactory;
using System.Data;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IGameRepository : IRepository
    {
        void Insert(IDbConnection connection, Game game, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Game game, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, int id, IDbTransaction transaction = null);
        Game SelectLastestGameByPlayerId(IDbConnection connection, int id, IDbTransaction transaction = null);
    }
}