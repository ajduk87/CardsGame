using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Models
{
    public class GameUpdateModel : GameBaseModel
    {
        public int Id { get; set; }
        public bool? IsWinner { get; set; }
    }
}
