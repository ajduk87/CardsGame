using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Dtoes
{
    public class GameRoundProcessDto : Dto
    {
        public IEnumerable<GameStepDto> GameStepDtoes { get; set; }
    }
}
