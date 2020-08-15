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
    public interface IGameProgressDtoRepository : IRepository
    {
        GameProgressDto SelectByName(IDbConnection connection, string gamename);
    }
}
