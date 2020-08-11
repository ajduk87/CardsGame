﻿using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class GameStep : Entity
    {
        public Id Id { get; set; }
        public Id PlayerId { get; set; }
        public CardValue CardValue { get; set; }
        public IsStepWinner IsStepWinner { get; set; }
        public CardsLeft CardsLeft { get; set; }
    }
}