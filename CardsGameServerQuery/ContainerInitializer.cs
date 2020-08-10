using Autofac;
using Autofac.Integration.WebApi;
using CardsGameServerQuery.Registration;
using System.Reflection;
namespace CardsGameServerQuery
{
    public static class ContainerInitializer
    {
        private static ContainerBuilder objContainer { get; set; }
        public static Autofac.IContainer Container { get; set; }

        public static ILifetimeScope GetContainer()
        {
            objContainer = new ContainerBuilder();

            objContainer.RegisterApiControllers(Assembly.GetExecutingAssembly())/*.PropertiesAutowired()*/;


            objContainer.RegisterModule<RegistrationModule>();



            Container = objContainer.Build();

            return Container;
        }
    }
}
