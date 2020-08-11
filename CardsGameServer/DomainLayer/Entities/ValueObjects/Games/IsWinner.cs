namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Games
{
    public class IsWinner : ValueObject<IsWinner>
    {
        public bool Content;

        public IsWinner(bool Content)
        {
            this.Content = Content;
        }

        public static explicit operator IsWinner(bool amount)
        {
            return new IsWinner(amount);
        }

        public static implicit operator bool(IsWinner amount)
        {
            return amount.Content;
        }
    }
}