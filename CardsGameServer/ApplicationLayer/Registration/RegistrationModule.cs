using Autofac;
using CardsGameServer.ApplicationLayer.Controllers;
using CardsGameServer.ApplicationLayer.Services.Configuration;
using CardsGameServer.ApplicationLayer.Services.GameServices;
using System.Web.Http;

namespace CardsGameServer.ApplicationLayer.Registration
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<DatabaseConnectionFactory>()
                       .As<IDatabaseConnectionFactory>();

            objContainer.RegisterType<ConfigurationService>()
                       .As<IConfigurationService>();

            objContainer.RegisterType<GameAppService>()
                       .As<IGameAppService>();

            base.Load(objContainer);
        }
    }
}