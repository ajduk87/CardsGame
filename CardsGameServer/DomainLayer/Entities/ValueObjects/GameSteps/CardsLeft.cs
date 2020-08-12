using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps
{
    public class CardsLeft : ValueObject<CardsLeft>
    {
        public int Content { get; }

        public CardsLeft(int Content)
        {
            this.Content = Content;
        }
        public CardsLeft Add(CardsLeft otherCardsLeft)
        {
            return new CardsLeft(this.Content + otherCardsLeft.Content);
        }


        public static explicit operator CardsLeft(int cardsLeft)
        {
            return new CardsLeft(cardsLeft);
        }

        public static implicit operator int(CardsLeft cardsLeft)
        {
            return cardsLeft.Content;
        }
    }
}
