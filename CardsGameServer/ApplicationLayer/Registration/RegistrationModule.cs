using Autofac;
using CardsGameServer.ApplicationLayer.Controllers;
using CardsGameServer.ApplicationLayer.Services.Configuration;
using CardsGameServer.ApplicationLayer.Services.GameServices;
using CardsGameServer.ApplicationLayer.Services.PlayerServices;
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

            objContainer.RegisterType<PlayerAppServices>()
                       .As<IPlayerAppServices>();

            base.Load(objContainer);
        }
    }
}