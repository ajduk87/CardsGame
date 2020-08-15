using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Repositories.Game
{
    public class WinnerGetter : IWinnerGetter
    {
        public string GetWinnerName(string winnerPath, string gamename)
        {
            return File.ReadAllLines(winnerPath).ToList()
                                                         .Where(winner => winner.Split(' ')[0] == gamename)
                                                         .Single();
        }
    }
}
