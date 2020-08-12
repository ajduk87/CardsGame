using Autofac;
using CardsGameServer.DomainLayer.Services;

namespace CardsGameServer.DomainLayer.Registration
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<GameService>()
                        .Keyed<IGameService>(typeof(GameService))
                        .As<IGameService>();

            objContainer.RegisterType<GameProgressService>()
                        .Keyed<IGameProgressService>(typeof(GameProgressService))
                        .As<IGameProgressService>();

            base.Load(objContainer);
        }
    }
}