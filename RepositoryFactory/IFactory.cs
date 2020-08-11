namespace RepositoryFactory
{
    public interface IFactory
    {
        T Create<T>() where T : IRepository;
    }
}