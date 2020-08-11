namespace CardsGameServer.DomainLayer.Entities.ValueObjects.Shared
{
    public class Name : ValueObject<Name>
    {
        public string Content { get; }

        public Name(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator Name(string name)
        {
            return new Name(name);
        }

        public static implicit operator string(Name name)
        {
            return name.Content;
        }
    }
}