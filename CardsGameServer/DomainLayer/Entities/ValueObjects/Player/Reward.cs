using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Player
{
    public class Reward : ValueObject<Reward>
    {
        public double Content;

        public Reward(double Content)
        {
            this.Content = Content;
        }

        public static explicit operator Reward(double numberOfSteps)
        {
            return new Reward(numberOfSteps);
        }

        public static implicit operator double(Reward numberOfSteps)
        {
            return numberOfSteps.Content;
        }
    }
}
