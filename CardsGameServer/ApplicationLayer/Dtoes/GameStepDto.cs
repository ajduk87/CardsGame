using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Dtoes
{
    public class GameStepDto : Dto
    {
        public string GameName { get; set; }
        public int GameStepId { get; set; }
        public int PlayerId { get; set; }
        public int CardValue { get; set; }
        public string CardSuit { get; set; }
        public int CardsLeft { get; set; }
    }
}
