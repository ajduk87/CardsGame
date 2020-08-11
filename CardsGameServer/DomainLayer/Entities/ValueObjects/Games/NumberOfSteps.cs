namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Games
{
    public class NumberOfSteps : ValueObject<NumberOfSteps>
    {
        public int Content;

        public NumberOfSteps(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator NumberOfSteps(int numberOfSteps)
        {
            return new NumberOfSteps(numberOfSteps);
        }

        public static implicit operator int(NumberOfSteps numberOfSteps)
        {
            return numberOfSteps.Content;
        }
    }
}