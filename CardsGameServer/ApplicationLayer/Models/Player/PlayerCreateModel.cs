﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Models.Player
{
    public class PlayerCreateModel
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
