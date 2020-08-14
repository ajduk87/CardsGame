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
        public GameViewDto SelectById(IDbConnection connection, int id)
        {
            return connection.Query<GameViewDto>(GameQueries.Select, new { id }).Single();
        }

        public IEnumerable<GameViewDto> SelectByName(IDbConnection connection, string name)
        {
            return connection.Query<GameViewDto>(GameQueries.SelectByName, new { name });
        }
    }
}
