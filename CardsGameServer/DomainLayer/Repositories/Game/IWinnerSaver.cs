using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Repositories.Game
{
    public interface IWinnerSaver : IRepository
    {
        void Save(string winnerPath, string winner);
    }
}
