﻿using Autofac;
using CardsGameServer.ApplicationLayer.Models;
using CardsGameServer.ApplicationLayer.Validation;
using CardsGameServer.ApplicationLayer.Validation.Game;
using FluentValidation;
using System.Collections.Generic;

namespace CardsGameServer.ApplicationLayer.Registration
{
    public class RegistrationValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {

            objContainer.RegisterType<GameListCreateValidator>()
                        .Keyed<IValidator>("gameCreateModels")
                        .As<IValidator>()
                        .InstancePerLifetimeScope();

            objContainer.RegisterType<GameUpdateValidator>()
                       .Keyed<IValidator>("gameUpdateModel")
                       .As<IValidator>()
                       .InstancePerLifetimeScope();

            base.Load(objContainer);
        }
    }
}