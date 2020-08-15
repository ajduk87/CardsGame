using CardsGameServer.DomainLayer.Entities.ScoreEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.PlayerEntities.RewardCalculation
{
    public interface IRewardCalculation
    {
        Reward Calculate(Score score);
    }
}
