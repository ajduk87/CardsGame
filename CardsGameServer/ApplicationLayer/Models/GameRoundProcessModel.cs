using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Models
{
    public class GameRoundProcessModel
    {
        public IEnumerable<GameStepModel> GameStepModels { get; set; }
    }
}
