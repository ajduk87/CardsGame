namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GamesNumberOfPlayers
{
    public class NumberOfPlayers : ValueObject<NumberOfPlayers>
    {
        public int Content;

        public NumberOfPlayers(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator NumberOfPlayers(int numberOfPlayers)
        {
            return new NumberOfPlayers(numberOfPlayers);
        }

        public static implicit operator int(NumberOfPlayers numberOfPlayers)
        {
            return numberOfPlayers.Content;
        }
    }
}