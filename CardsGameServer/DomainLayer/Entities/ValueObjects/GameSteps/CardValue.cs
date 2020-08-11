namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps
{
    public class CardValue : ValueObject<CardValue>
    {
        public int Content;

        public CardValue(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator CardValue(int amount)
        {
            return new CardValue(amount);
        }

        public static implicit operator int(CardValue amount)
        {
            return amount.Content;
        }
    }
}