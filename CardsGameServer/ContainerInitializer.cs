using Autofac;
using Autofac.Integration.WebApi;
using ApplicationLayer = CardsGameServer.ApplicationLayer.Registration;
using DomainLayer = CardsGameServer.DomainLayer.Registration;
using System.Reflection;

namespace CardsGameServer
{
    public static class ContainerInitializer
    {
        private static ContainerBuilder objContainer { get; set; }
        public static Autofac.IContainer Container { get; set; }

        public static IContainer GetContainer()
        {
            objContainer = new ContainerBuilder();

            objContainer.RegisterModule<ApplicationLayer.Registration.RegistrationModule>();
            objContainer.RegisterModule<ApplicationLayer.Registration.RegistrationValidatorsModule>();

            objContainer.RegisterModule<DomainLayer.Registration.RegistrationModule>();


            objContainer.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            Container = objContainer.Build();

            return Container;
        }
    }
}