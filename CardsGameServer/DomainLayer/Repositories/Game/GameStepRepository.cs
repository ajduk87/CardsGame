﻿using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Repositories.Sql;
using System.Data;
using Dapper;

namespace CardsGameServer.DomainLayer.Repositories
{
    public class GameStepRepository : IGameStepRepository
    {
        public int Insert(IDbConnection connection, GameStep gameStep, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<int>(GameStepQueries.Insert, new
            {
                playerid = gameStep.PlayerId.Content,
                cardvalue = gameStep.CardValue.Content,
                cardsuit = gameStep.CardSuit.Content,
                isstepwinner = gameStep.IsStepWinner.Content,
                cardsleft = gameStep.CardsLeft.Content
            }, transaction);
        }

        public void Update(IDbConnection connection, GameStep gameStep, IDbTransaction transaction = null)
        {
            connection.Execute(GameStepQueries.Update, new
            {
                id = gameStep.Id.Content,
                playerid = gameStep.PlayerId.Content,
                cardvalue = gameStep.CardValue.Content,
                isstepwinner = gameStep.IsStepWinner.Content,
                cardsleft = gameStep.CardsLeft.Content
            }, transaction);
        }

        public void InsertChild(IDbConnection connection, GamesGameStep gamesGameStep, IDbTransaction transaction = null)
        {
            connection.Execute(GameStepQueries.InsertChild, new
            {
                gamename = gamesGameStep.GameName.Content,
                gamestepid = gamesGameStep.GameStepId.Content
            }, transaction);
        }
    }
}