﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery.Dtoes
{
    public class PlayerStatusDto : Dto
    {
        public int PlayerId { get; set; }
        public int CardValue { get; set; }
        public string CardSuit { get; set; }
        public string PlayingPile { get; set; }
        public string DiscardPile { get; set; }
        public int CardsLeft { get; set; }
    }
}