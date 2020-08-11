namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps
{
    public class IsStepWinner : ValueObject<IsStepWinner>
    {
        public bool Content;

        public IsStepWinner(bool Content)
        {
            this.Content = Content;
        }

        public static explicit operator IsStepWinner(bool isStepWinner)
        {
            return new IsStepWinner(isStepWinner);
        }

        public static implicit operator bool(IsStepWinner isStepWinner)
        {
            return isStepWinner.Content;
        }
    }
}