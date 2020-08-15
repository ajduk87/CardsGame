using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Dtoes.Player
{
    public class DrawStatusDto : Dto
    {
        public string Name { get; set; }
        public string TopCard { get; set; }
        public string PlayingPile { get; set; }
        public string DiscardPile { get; set; }
    }
}
