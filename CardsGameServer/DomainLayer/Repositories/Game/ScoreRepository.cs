using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using CardsGameServer.DomainLayer.Repositories.Sql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        public void Insert(IDbConnection connection, Score score, IDbTransaction transaction = null)
        {
            connection.Execute(ScoreQueries.Insert, new
            {
                playerid = score.PlayerId.Content,
                numberofwins = score.NumberOfWins.Content
            });
        }

        public void Update(IDbConnection connection, Score score, IDbTransaction transaction = null)
        {
            connection.Execute(ScoreQueries.Update, new
            {
                id = score.Id.Content,
                playerid = score.PlayerId.Content,
                numberofwins = score.NumberOfWins.Content
            });
        }

        public Score SelectPlayerId(IDbConnection connection, int playerid, IDbTransaction transaction = null)
        {
            return connection.Query<Score>(ScoreQueries.SelectByPlayerId, new { playerid }).Single();
        }
    }
}
