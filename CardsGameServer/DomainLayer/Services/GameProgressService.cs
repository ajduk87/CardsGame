using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryFactory;

namespace CardsGameServer.DomainLayer.Services
{
    public class GameProgressService : IGameProgressService
    {
        private readonly IGameProgressRepository gameProgressRepository;

        public GameProgressService()
        {
            this.gameProgressRepository = Factory.Create<IGameProgressRepository>();
        }

        public void InsertProgress(IDbConnection connection, GameProgress gameProgress, IDbTransaction transaction = null) =>
            this.gameProgressRepository.Insert(connection, gameProgress, transaction);
    }
}
