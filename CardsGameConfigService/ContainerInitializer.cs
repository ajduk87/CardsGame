using Autofac;
using System.Reflection;
using Autofac.Integration.WebApi;
using CardsGameConfigService.Registration;

namespace CardsGameConfigService
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