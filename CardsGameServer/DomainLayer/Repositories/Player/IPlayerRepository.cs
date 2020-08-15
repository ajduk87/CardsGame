using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Dtoes.Player;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IPlayerRepository : IRepository
    {
        DrawStatusDto SelectDrawStatus(IDbConnection connection, int id, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, int id, IDbTransaction transaction = null);
        int Insert(IDbConnection connection, Player player, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Player player, IDbTransaction transaction = null);
    }
}
