using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Models
{
    public class GameBaseModel
    {
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
    }
}
