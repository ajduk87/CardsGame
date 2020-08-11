using Autofac;
using CardsGameServer.ApplicationLayer.Registration.Containers;
using FluentValidation;
using System;

namespace CardsGameServer.ApplicationLayer.Validation
{
    public class ValidatorFactory
    {
        private readonly RegistrationValidators registrationValidators;

        public ValidatorFactory()
        {
            this.registrationValidators = new RegistrationValidators();
        }

        public IValidator CreateInstance(string parameterName)
        {
            IValidator validator = this.registrationValidators.Instance.Container.ResolveKeyed<IValidator>(parameterName);
            return validator;
        }
    }
}