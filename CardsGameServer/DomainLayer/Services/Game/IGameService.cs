using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
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
        bool IsGameOver(IEnumerable<GameStep> gameSteps);
        void Terminate(IDbConnection connection, Player winner, IDbTransaction transaction = null);
        void RecordWinner(IDbConnection connection, Player winner, IDbTransaction transaction = null);
    }
}
