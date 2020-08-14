using CardsGameServerQuery.Dtoes;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Repositories.Game
{
    public interface IGameDtoRepository : IRepository
    {
        GameViewDto SelectById(IDbConnection connection, int id);
        IEnumerable<GameViewDto> SelectByName(IDbConnection connection, string name);
    }
}
