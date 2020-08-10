using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Registration
{
    public class RegistrationValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
           /* objContainer.RegisterType<ValidatorFactory>()
                   .As<IValidatorFactory>()
                   .SingleInstance();

            objContainer.RegisterType<StorageCreateValidator>()
                        .Keyed<IValidator>(typeof(StorageCreateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();*/


            base.Load(objContainer);
        }
    }
}
