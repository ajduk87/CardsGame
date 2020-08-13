using CardsGameServer.DomainLayer.Entities.GamesEntities;
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
    public class GameProgressRepository : IGameProgressRepository
    {
        public void Insert(IDbConnection connection, GameProgress gameProgress, IDbTransaction transaction = null)
        {
            connection.Execute(GameProgressQueries.Insert, new
            {
                gamename = gameProgress.GameName.Content,
                isinprogress = gameProgress.IsInProgress.Content
            });
        }

        public void UpdateStatus(IDbConnection connection, string gamename, bool isinprogress, IDbTransaction transaction = null)
        {
            connection.Execute(GameProgressQueries.UpdateStatus, new
            {
                gamename = gamename,
                isinprogress = isinprogress
            });
        }
    }
}
