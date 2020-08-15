using CardsGameServerQuery.Dtoes;
using CardsGameServerQuery.Repositories.Sql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Repositories.Game
{
    public class GameProgressDtoRepository : IGameProgressDtoRepository
    {
        public GameProgressDto SelectByName(IDbConnection connection, string gamename)
        {
            return connection.Query<GameProgressDto>(GameProgressQueries.Select, new { gamename }).Single();
        }
    }
}
