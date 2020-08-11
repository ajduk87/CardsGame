using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public class DbFactory : IFactory
    {
        private readonly Dictionary<Type, Type> _repositories;

        public DbFactory(Dictionary<Type, Type> repositoryMap)
        {
            _repositories = repositoryMap;
        }

        public T Create<T>() where T : IRepository
        {
            Type repositoryClass;
            Type repositoryType = typeof(T);
            if (_repositories.TryGetValue(repositoryType, out repositoryClass))
            {
                return (T)Activator.CreateInstance(repositoryClass);
            }

            throw new Exception($"Cannot create repository for {repositoryType.FullName}.");
        }
    }
}
