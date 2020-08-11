using Autofac;
using CardsGameConfigService.Registration.Containers;
using FluentValidation;
using System;

namespace CardsGameConfigService.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly RegistrationValidators registrationValidators;

        public ValidatorFactory()
        {
            this.registrationValidators = new RegistrationValidators();
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = this.registrationValidators.Instance.Container.ResolveKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}