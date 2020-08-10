using Autofac;

namespace CardsGameConfigService.Registration
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            //objContainer.RegisterType<ConfigurationService>()
            //            .As<IConfigurationService>();

            base.Load(objContainer);
        }
    }
}
