namespace RepositoryFactory
{
    public static class Factory
    {
        private static IFactory _factory;

        public static void Initialize(IFactory factory)
        {
            if (factory == null)
            {
                return;
            }

            _factory = factory;
        }

        public static T Create<T>() where T : IRepository
        {
            return _factory.Create<T>();
        }
    }
}