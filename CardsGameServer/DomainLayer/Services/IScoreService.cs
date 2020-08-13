using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public interface IScoreService
    {
        void IncreaseScore(IDbConnection connection, Player winner, IDbTransaction transaction = null);
    }
}
