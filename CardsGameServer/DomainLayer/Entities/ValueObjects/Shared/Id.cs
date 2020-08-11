namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Shared
{
    public class Id : ValueObject<Id>
    {
        public long Content { get; private set; }

        public Id(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator Id(long id)
        {
            return new Id(id);
        }

        public static implicit operator long(Id id)
        {
            return id.Content;
        }
    }
}