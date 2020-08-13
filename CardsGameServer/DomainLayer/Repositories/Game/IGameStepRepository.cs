using CardsGameServer.DomainLayer.Entities.GamesEntities;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IGameStepRepository : IRepository
    {
        int Insert(IDbConnection connection, GameStep gameStep, IDbTransaction transaction = null);
        void Update(IDbConnection connection, GameStep gameStep, IDbTransaction transaction = null);
        void InsertChild(IDbConnection connection, GamesGameStep gamesGameStep, IDbTransaction transaction = null);
    }
}
