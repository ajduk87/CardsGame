using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CardsGameConfigService.Models;
using CardsGameConfigService.Validation;
using CardsGameConfigService.Validation.PlayersNumber;
using FluentValidation;

namespace CardsGameConfigService.Registration
{
    public class RegistrationValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ValidatorFactory>()
                   .As<IValidatorFactory>()
                   .SingleInstance();

            objContainer.RegisterType<PlayerNumberCreateValidator>()
                      .Keyed<IValidator>(typeof(PlayerNumberCreateModel))
                      .As<IValidator>()
                      .InstancePerLifetimeScope();

            objContainer.RegisterType<PlayerNumberUpdateValidator>()
                        .Keyed<IValidator>(typeof(PlayerNumberUpdateModel))
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            base.Load(objContainer);
        }
    }
}
