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

            objContainer.RegisterType<ShiffleService>()
                        .Keyed<IShiffleService>(typeof(ShiffleService))
                        .As<IShiffleService>();

            objContainer.RegisterType<CroupierService>()
                        .Keyed<ICroupierService>(typeof(CroupierService))
                        .As<ICroupierService>();

            objContainer.RegisterType<GameStepService>()
                       .Keyed<IGameStepService>(typeof(GameStepService))
                       .As<IGameStepService>();

            objContainer.RegisterType<TableService>()
                      .Keyed<ITableService>(typeof(TableService))
                      .As<ITableService>();

            objContainer.RegisterType<EvaulationService>()
                      .Keyed<IEvaulationService>(typeof(EvaulationService))
                      .As<IEvaulationService>();

            objContainer.RegisterType<PlayerService>()
                     .Keyed<IPlayerService>(typeof(PlayerService))
                     .As<IPlayerService>();

            objContainer.RegisterType<ScoreService>()
                   .Keyed<IScoreService>(typeof(ScoreService))
                   .As<IScoreService>();

            base.Load(objContainer);
        }
    }
}