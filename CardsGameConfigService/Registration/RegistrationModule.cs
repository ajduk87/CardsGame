using Autofac;
using CardsGameConfigService.Serialization;

namespace CardsGameConfigService.Registration
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<JsonSerializer>()
                        .As<IJsonSerializer>();

            base.Load(objContainer);
        }
    }
}
