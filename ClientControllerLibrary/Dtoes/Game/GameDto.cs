using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientControllerLibrary.Dtoes.Game
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public bool? IsWinner { get; set; }
    }
}
