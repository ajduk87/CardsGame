using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Models
{
    public class GameStepModel
    {
        public int GameId { get; set; }
        public int GameStepId { get; set; }
        public int PlayerId { get; set; }
        public int CardValue { get; set; }
        public string CardSuit { get; set; }
        public int CardsLeft { get; set; }
    }
}
