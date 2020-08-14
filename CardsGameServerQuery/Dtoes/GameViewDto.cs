using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Dtoes
{
    public class GameViewDto : Dto
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public int NumberOfSteps { get; set; }
        public bool IsWinner { get; set; }
    }
}
