namespace CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps
{
    public class CardValue : ValueObject<CardValue>
    {
        public int Content;

        public CardValue(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator CardValue(int cardValue)
        {
            return new CardValue(cardValue);
        }

        public static implicit operator int(CardValue cardValue)
        {
            return cardValue.Content;
        }
    }
}