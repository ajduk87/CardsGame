﻿using CardsGameServer.DomainLayer.Entities.GamesEntities;
using RepositoryFactory;
using System.Data;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface IGameRepository : IRepository
    {
        void Insert(IDbConnection connection, Game game, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Game game, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, int id, IDbTransaction transaction = null);
    }
}