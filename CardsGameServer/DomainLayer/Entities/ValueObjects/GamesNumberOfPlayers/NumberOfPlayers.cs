namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GamesNumberOfPlayers
{
    public class NumberOfPlayers : ValueObject<NumberOfPlayers>
    {
        public int Content;

        public NumberOfPlayers(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator NumberOfPlayers(int amount)
        {
            return new NumberOfPlayers(amount);
        }

        public static implicit operator int(NumberOfPlayers amount)
        {
            return amount.Content;
        }
    }
}