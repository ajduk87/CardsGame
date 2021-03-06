﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Models
{
    public class PlayerStatusModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int CardValue { get; set; }
        public int CardSuit { get; set; }
        public string PlayingPile { get; set; }
        public string DiscardPile { get; set; }
        public int CardsLeft { get; set; }
        public int GameStepId { get; set; }
    }
}
