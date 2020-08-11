using CardsGameConfigService.Models;
using FluentValidation;

namespace CardsGameConfigService.Validation.PlayersNumber
{
    public class PlayerNumberUpdateValidator : AbstractValidator<PlayerNumberUpdateModel>
    {
        private readonly int maxNumberOfPlayers = 4;

        public PlayerNumberUpdateValidator()
        {
            RuleFor(p => p.NumberOfPlayers)
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

        private bool ValidateNumberOfPlayersIsNotNegative(int numberOfPlayers)
        {
            return numberOfPlayers > 0; ;
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