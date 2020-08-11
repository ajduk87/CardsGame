namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Shared
{
    public class NumberOfWins : ValueObject<NumberOfWins>
    {
        public int Content;

        public NumberOfWins(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator NumberOfWins(int numberOfWins)
        {
            return new NumberOfWins(numberOfWins);
        }

        public static implicit operator int(NumberOfWins numberOfWins)
        {
            return numberOfWins.Content;
        }
    }
}