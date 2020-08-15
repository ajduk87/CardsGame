using CardsGameServer.DomainLayer.Entities.PlayerEntities.RewardCalculation;
using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Player;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Entities.PlayerEntities
{
    public class Player : Entity
    {
        public Name Name { get; set; }
        public Card TopCard { get; set; }
        public PlayingPile PlayingPile { get; set; }
        public DiscardPile DiscardPile { get; set; }
        public Reward Reward { get; set; }

        private IRewardCalculation rewardCalculation { get; set; }

        public Player()
        {
            this.rewardCalculation = new RewardForLowRating();
        }

        public Player(IRewardCalculation rewardCalculation)
        {
            this.rewardCalculation = rewardCalculation;
        }

        public void Rewarding(Score score) =>
            this.Reward = this.rewardCalculation.Calculate(score);
    }
}