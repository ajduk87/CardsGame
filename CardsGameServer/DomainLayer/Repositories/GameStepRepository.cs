using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Repositories.Sql;
using System.Data;
using Dapper;

namespace CardsGameServer.DomainLayer.Repositories
{
    public class GameStepRepository : IGameStepRepository
    {
        public void Insert(IDbConnection connection, GameStep gameStep, IDbTransaction transaction = null)
        {
            connection.Execute(GameStepQueries.Insert, new
            {
                playerid = gameStep.PlayerId.Content,
                cardvalue = gameStep.CardValue.Content,
                isstepwinner = gameStep.IsStepWinner.Content,
                discardpile = gameStep.DiscardPile.ToString(),
                playingpile = gameStep.PlayingPile.ToString(),
                cardsleft = gameStep.CardsLeft.Content
            });
        }
    }
}