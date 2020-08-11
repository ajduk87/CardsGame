using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RepositoryFactory
{
    public static class Finder
    {
        public static Dictionary<Type, Type> FindRepositoryTypes(string baseNamespace)
        {
            if (String.IsNullOrEmpty(baseNamespace))
            {
                return new Dictionary<Type, Type>();
            }

            Dictionary<Type, Type> repositoryMap = new Dictionary<Type, Type>();
            var type = typeof(IRepository);
            Assembly.Load(baseNamespace); //Manual loading assembly, it is not loaded during startup time
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            var types = assemblies.SelectMany(s => s.GetTypes())
                                  .Where(p => type.IsAssignableFrom(p) && type != p);
            var repTypes = assemblies.Where(a => a.FullName.StartsWith(baseNamespace))
                                     .SelectMany(s => s.GetTypes())
                                     .Where(p => type.IsAssignableFrom(p));

            var iRepInterfaces = types.Where(t => t.IsInterface);
            var repositoryTypes = repTypes.Where(t => t.IsClass);
            foreach (var @interface in iRepInterfaces)
            {
                if (!repositoryMap.ContainsKey(@interface))
                {
                    var rep = repositoryTypes.FirstOrDefault(r => r.GetInterfaces().Contains(@interface));
                    if (rep == null)
                    {
                        Debug.Print($"{@interface.FullName} is not used in the assembly {baseNamespace}!");
                        continue;
                    }
                    repositoryMap.Add(@interface, rep);
                }
            }
            return repositoryMap;
        }
    }
}