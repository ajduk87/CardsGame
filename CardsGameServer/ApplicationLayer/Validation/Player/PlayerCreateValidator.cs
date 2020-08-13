using CardsGameServer.ApplicationLayer.Models;
using CardsGameServer.ApplicationLayer.Models.Player;
using CardsGameServer.DomainLayer.Repositories;
using FluentValidation;
using Npgsql;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Validation.Player
{
    public class PlayerCreateValidator : AbstractValidator<PlayerCreateModel>
    {
        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        private readonly IPlayerRepository playerRepository;

        public PlayerCreateValidator()
        {
            this.databaseConnectionFactory = new DatabaseConnectionFactory();

            this.playerRepository = Factory.Create<IPlayerRepository>();

            RuleFor(p => p.Name)
                 .NotEmpty();

            RuleFor(p => p.LastName)
                .NotEmpty();

        }
    }
}
