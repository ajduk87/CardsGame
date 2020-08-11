namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Games
{
    public class NumberOfSteps : ValueObject<NumberOfSteps>
    {
        public int Content;

        public NumberOfSteps(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator NumberOfSteps(int amount)
        {
            return new NumberOfSteps(amount);
        }

        public static implicit operator int(NumberOfSteps amount)
        {
            return amount.Content;
        }
    }
}