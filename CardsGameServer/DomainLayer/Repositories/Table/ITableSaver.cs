using RepositoryFactory;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Repositories
{
    public interface ITableSaver : IRepository
    {
        void Save(string tablePath, IEnumerable<string> cards);
        IEnumerable<string> Peek(string tablePath);
        IEnumerable<string> GetOn(string tablePath);
    }
}