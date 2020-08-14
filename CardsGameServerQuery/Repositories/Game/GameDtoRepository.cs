using CardsGameServerQuery.Dtoes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CardsGameServerQuery.Repositories.Sql;

namespace CardsGameServerQuery.Repositories.Game
{
    public class GameDtoRepository : IGameDtoRepository
    {
        public GameDto SelectById(IDbConnection connection, int id)
        {
            return connection.Query<GameDto>(GameQueries.Select, new { id }).Single();
        }

        public IEnumerable<GameDto> SelectByName(IDbConnection connection, string name)
        {
            return connection.Query<GameDto>(GameQueries.SelectByName, new { name });
        }
    }
}
