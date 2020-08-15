using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.PlayerEntities.RewardCalculation
{
    public class RewardForLowRating : IRewardCalculation
    {
        public Reward Calculate(Score score)
        {
            return new Reward(2.2 * score.NumberOfWins);
        }
    }
}
