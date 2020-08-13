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
        Player SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Player player, IDbTransaction transaction = null);
    }
}
