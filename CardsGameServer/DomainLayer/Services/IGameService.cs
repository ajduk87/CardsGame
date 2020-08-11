using CardsGameServer.DomainLayer.Entities.GamesEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IGameService
    {
        void InsertGame(IDbConnection connection, IEnumerable<Game> games, IDbTransaction transaction = null);
        void UpdateGame(IDbConnection connection, Game game, IDbTransaction transaction = null);
    }
}
