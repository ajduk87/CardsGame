using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using CardsGameServer.DomainLayer.Repositories;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CardsGameServer.DomainLayer.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository scoreRepository;

        public ScoreService()
        {
            this.scoreRepository = Factory.Create<IScoreRepository>();
        }


        public void IncreaseScore(IDbConnection connection, Player winner, IDbTransaction transaction = null)
        {
            Score score = this.scoreRepository.SelectPlayerId(connection, winner.Id, transaction);
            score.NumberOfWins = new NumberOfWins(score.NumberOfWins + 1);
            this.scoreRepository.Update(connection, score, transaction);
        }
    }
}