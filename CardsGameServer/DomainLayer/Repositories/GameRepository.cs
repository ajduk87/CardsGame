using CardsGameServer.DomainLayer.Entities.GamesEntities;
using System.Data;
using Dapper;
using CardsGameServer.DomainLayer.Repositories.Sql;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using System.Linq;

namespace CardsGameServer.DomainLayer.Repositories
{
    public class GameRepository : IGameRepository
    {
        public void Insert(IDbConnection connection, Game game, IDbTransaction transaction = null)
        {
            connection.Execute(GameQueries.Insert, new
            {
                name = game.Name.Content,
                playerid = game.PlayerId.Content,
                numberofsteps = game.NumberOfSteps.Content,
                iswinner = game.IsWinner.Content
            });
        }

        public void Update(IDbConnection connection, Game game, IDbTransaction transaction = null)
        {
            connection.Execute(GameQueries.Update, new
            {
                id = game.Id.Content,
                name = game.Name.Content,
                playerid = game.PlayerId.Content,
                numberofsteps = game.NumberOfSteps.Content,
                iswinner = game.IsWinner.Content
            });
        }

        public bool Exists(IDbConnection connection, int id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(GameQueries.Exists, new { id });
        }

        public Game SelectLastestGameByPlayerId(IDbConnection connection, int playerid, IDbTransaction transaction = null)
        {
            return connection.Query<Game>(GameQueries.SelectByPlayerId, new { playerid }).Single();
        }
    }
}