using Autofac;
using System;

namespace CardsGameServer.ApplicationLayer.Registration.Containers
{
    public sealed class RegistrationValidators
    {
        private ContainerBuilder objContainer { get; set; }
        public Autofac.IContainer Container { get; set; }

        public readonly Lazy<RegistrationValidators>
        lazy =
        new Lazy<RegistrationValidators>
            (() => new RegistrationValidators());

        public RegistrationValidators Instance { get { return lazy.Value; } }

        public RegistrationValidators()
        {
            this.Register();
        }

        private void Register()
        {
            objContainer = new ContainerBuilder();
            objContainer.RegisterModule<RegistrationValidatorsModule>();
            Container = objContainer.Build();
        }
    }
}