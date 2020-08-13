using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using RepositoryFactory;
using System.Data;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IScoreRepository : IRepository
    {
        void Insert(IDbConnection connection, Score score, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Score score, IDbTransaction transaction = null);

        Score SelectPlayerId(IDbConnection connection, int id, IDbTransaction transaction = null);
    }
}