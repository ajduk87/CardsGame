﻿using CardsGameServer.DomainLayer.Entities.GamesEntities;
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
        void SetupCards(IDbConnection connection, IEnumerable<Player> players, IDbTransaction transaction = null);
        void SetCardsToWinner(IDbConnection connection, Player winner, IDbTransaction transaction = null);
        IEnumerable<GameStep> StartTheGame(IEnumerable<Player> players);
        Player PickWinner(IEnumerable<Player> allplayers, IEnumerable<GameStep> gameSteps);
    }
}
