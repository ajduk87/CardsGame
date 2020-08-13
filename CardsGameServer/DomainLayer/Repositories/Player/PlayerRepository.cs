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

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(PlayerQueries.Exists, new { id });
        }

        public int Insert(IDbConnection connection, Player player, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<int>(PlayerQueries.Insert, new
            {
                name = player.Name.Content,
                topcard = player.TopCard.ToString(),
                discardpile = player.DiscardPile.ToString(),
                playingpile = player.PlayingPile.ToString()
            }, transaction);
        }

        public void Update(IDbConnection connection, Player player, IDbTransaction transaction = null)
        {
            connection.Execute(PlayerQueries.Update, new
            {
                id = player.Id.Content,
                name = player.Name.Content,
                topcard = player.TopCard.ToString(),
                playingpile = player.PlayingPile.ToString(),
                discardpile = player.DiscardPile.ToString()
            });
        }
    }
}
