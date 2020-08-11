namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps
{
    public class IsStepWinner : ValueObject<IsStepWinner>
    {
        public bool Content;

        public IsStepWinner(bool Content)
        {
            this.Content = Content;
        }

        public static explicit operator IsStepWinner(bool amount)
        {
            return new IsStepWinner(amount);
        }

        public static implicit operator bool(IsStepWinner amount)
        {
            return amount.Content;
        }
    }
}