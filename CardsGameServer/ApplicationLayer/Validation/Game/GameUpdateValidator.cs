using CardsGameServer.ApplicationLayer.Models;
using CardsGameServer.DomainLayer.Repositories;
using FluentValidation;
using Npgsql;
using RepositoryFactory;

namespace CardsGameServer.ApplicationLayer.Validation.Game
{
    public class GameUpdateValidator : AbstractValidator<GameUpdateModel>
    {
        private readonly int maxNumberOfPlayers = 4;

        private readonly IGameRepository gameRepository;
        private readonly IPlayerRepository playerRepository;

        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public GameUpdateValidator()
        {
            this.databaseConnectionFactory = new DatabaseConnectionFactory();

            this.gameRepository = Factory.Create<IGameRepository>();
            this.playerRepository = Factory.Create<IPlayerRepository>();

            RuleFor(g => g.Id)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .Must(ValidateGameId)
                 .WithMessage("The game specified doesn't exist in the database");

            RuleFor(g => g.PlayerId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidatePlayerId)
                .WithMessage("The game specified doesn't exist in the database");

            RuleFor(g => g.Name)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .Must(ValidateIsNameStartsWithGame)
                 .WithMessage("Name of game must be start with word GAME.");

            RuleFor(g => g.NumberOfPlayers)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .Must(ValidateNumberOfPlayersIsNotNegative)
                 .WithMessage("Number of players can't be negative.")
                 .Must(ValidateNumberOfPlayersIsNotZero)
                 .WithMessage("Number of players can't be 0.")
                 .Must(ValidateNumberOfPlayersIsNotOne)
                 .WithMessage("Number of players can't be 1.")
                 .Must(ValidateMaxNumberOfPlayers)
                 .WithMessage("Number of players can't be greater than 4.");
        }

        private bool ValidateGameId(int id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                return this.gameRepository.Exists(connection, id);
            }
        }

        private bool ValidatePlayerId(int id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                return this.playerRepository.Exists(connection, id);
            }
        }

        private bool ValidateIsNameStartsWithGame(string name)
        {
            return name.StartsWith("game");
        }

        private bool ValidateNumberOfPlayersIsNotNegative(int numberOfPlayers)
        {
            return numberOfPlayers > 0;
        }

        private bool ValidateNumberOfPlayersIsNotZero(int numberOfPlayers)
        {
            return numberOfPlayers != 0;
        }

        private bool ValidateNumberOfPlayersIsNotOne(int numberOfPlayers)
        {
            return numberOfPlayers != 1;
        }

        private bool ValidateMaxNumberOfPlayers(int numberOfPlayers)
        {
            return maxNumberOfPlayers > numberOfPlayers;
        }
    }
}