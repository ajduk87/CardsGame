using Autofac;
using Autofac.Integration.WebApi;
using CardsGameServer.ApplicationLayer.Registration;
using System.Reflection;

namespace CardsGameServer
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
            objContainer.RegisterModule<RegistrationValidatorsModule>();

            Container = objContainer.Build();

            return Container;
        }
    }
}