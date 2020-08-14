using CardsGameServerQuery.Dtoes;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Repositories.Player
{
    public interface IPlayerDtoRepository : IRepository
    {
        IEnumerable<PlayerDto> SelectAll(IDbConnection connection, IDbTransaction transaction = null);
        IEnumerable<PlayerStatusDto> SelectPlayerStatusByGamename(IDbConnection connection, string gamename, int numberOfPlayers, IDbTransaction transaction = null);
    }
}
