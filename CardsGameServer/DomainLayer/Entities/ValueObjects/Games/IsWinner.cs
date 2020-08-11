namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Games
{
    public class IsWinner : ValueObject<IsWinner>
    {
        public bool Content;

        public IsWinner(bool Content)
        {
            this.Content = Content;
        }

        public static explicit operator IsWinner(bool isWinner)
        {
            return new IsWinner(isWinner);
        }

        public static implicit operator bool(IsWinner isWinner)
        {
            return isWinner.Content;
        }
    }
}