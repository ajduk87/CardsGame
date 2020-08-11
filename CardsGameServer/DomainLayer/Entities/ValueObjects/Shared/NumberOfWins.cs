namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Shared
{
    public class NumberOfWins : ValueObject<NumberOfWins>
    {
        public int Content;

        public NumberOfWins(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator NumberOfWins(int amount)
        {
            return new NumberOfWins(amount);
        }

        public static implicit operator int(NumberOfWins amount)
        {
            return amount.Content;
        }
    }
}