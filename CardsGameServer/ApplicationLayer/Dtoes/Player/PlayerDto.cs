﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Dtoes
{
    public class PlayerDto : Dto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string TopCard { get; set; }
        public string PlayingPile { get; set; }
        public string DiscardPile { get; set; }
    }
}
