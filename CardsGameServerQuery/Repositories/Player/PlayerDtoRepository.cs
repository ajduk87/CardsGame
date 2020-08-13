using CardsGameServerQuery.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using CardsGameServerQuery.Repositories.Sql;

namespace CardsGameServerQuery.Repositories.Player
{
    public class PlayerDtoRepository : IPlayerDtoRepository
    {
        public IEnumerable<PlayerStatusDto> SelectPlayerStatusByGamename(IDbConnection connection, string gamename, int numberOfPlayers, IDbTransaction transaction = null)
        {
            return connection.Query<PlayerStatusDto>(PlayerQueries.SelectByGameName, new { gamename, numberOfPlayers });
        }
    }
}
