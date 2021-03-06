﻿using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;

namespace CardsGameServer.DomainLayer.Entities.GamesEntities
{
    public class GameStep : AggregateRoot
    {
        public Id PlayerId { get; set; }
        public CardValue CardValue { get; set; }
        public CardSuit CardSuit { get; set; }
        public IsStepWinner IsStepWinner { get; set; }
        public CardsLeft CardsLeft { get; set; }
        public GamesGameStep GamesGameStep { get; set; }
    }
}