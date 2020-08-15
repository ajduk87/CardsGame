using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Dtoes.Player;
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
    public interface IPlayerService
    {
        int InsertPlayer(IDbConnection connection, Player player, IDbTransaction transaction = null);
        DrawStatusDto SelectDrawStatus(IDbConnection connection, int id, IDbTransaction transaction = null);
        void DrawCard(IDbConnection connection, Player player, IDbTransaction transaction = null);
        void SetupCards(IDbConnection connection, IEnumerable<Player> players, IDbTransaction transaction = null);
        void SetCardsToWinner(IDbConnection connection, Player winner, IDbTransaction transaction = null);
        IEnumerable<GameStep> StartTheGame(IEnumerable<Player> players);
        Player PickRoundWinner(IEnumerable<Player> allplayers, IEnumerable<GameStep> gameSteps);
        void ShuffleCards(IDbConnection connection, IEnumerable<Player> players, IDbTransaction transaction = null);
    }
}
