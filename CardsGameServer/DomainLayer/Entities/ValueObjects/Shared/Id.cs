namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Shared
{
    public class Id : ValueObject<Id>
    {
        public int Content { get; private set; }

        public Id(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator Id(int id)
        {
            return new Id(id);
        }

        public static implicit operator int(Id id)
        {
            return id.Content;
        }
    }
}