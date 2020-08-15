using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Repositories.Game
{
    public class WinnerSaver : IWinnerSaver
    {
        private void DeleteContent(string winnerPath)
        {
            List<string> content = File.ReadAllLines(winnerPath).ToList();
            content.Clear();
            File.WriteAllLines(winnerPath, content.ToArray());
        }

        public void Save(string winnerPath, string newWinner)
        {
            List<string> winners = File.ReadAllLines(winnerPath).ToList();
            winners.Add(newWinner);
            DeleteContent(winnerPath);
            File.WriteAllLines(winnerPath, winners);
        }
    }
}
