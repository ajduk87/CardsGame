using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Dtoes
{
    public class PlayerDto : Dto
    {
        public string Name { get; set; }
        public int NumberOfWins { get; set; }
    }
}
