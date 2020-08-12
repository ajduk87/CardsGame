using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CardsGameServer.DomainLayer.Repositories.Sql;

namespace CardsGameServer.DomainLayer.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public Player SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.Query<Player>(PlayerQueries.Select, new { id }).Single();
        }
    }
}
