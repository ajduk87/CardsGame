using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CardsGameServer.DomainLayer.Repositories
{
    public class TableSaver : ITableSaver
    {
        private void DeleteContent(string tablePath)
        {
            List<string> content = File.ReadAllLines(tablePath).ToList();
            content.Clear();
            File.WriteAllLines(tablePath, content.ToArray());
        }


        public void Save(string tablePath, IEnumerable<string> cards) =>
            File.WriteAllLines(tablePath, cards);
        public IEnumerable<string> Peek(string tablePath) =>
            File.ReadAllLines(tablePath);

        public IEnumerable<string> GetOn(string tablePath)
        {
            IEnumerable<string> cardsRepresentation = File.ReadAllLines(tablePath);

            DeleteContent(tablePath);

            return cardsRepresentation;
        }
    }
}