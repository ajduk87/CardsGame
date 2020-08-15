using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Repositories.Game
{
    public interface IWinnerGetter : IRepository
    {
        string GetWinnerName(string winnerPath, string gamename);
    }
}
