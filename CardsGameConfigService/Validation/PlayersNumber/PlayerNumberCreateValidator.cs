using CardsGameConfigService.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameConfigService.Validation.PlayersNumber
{
    public class PlayerNumberCreateValidator : AbstractValidator<PlayerNumberCreateModel>
    {
        private readonly int maxNumberOfPlayers = 4;

        public PlayerNumberCreateValidator()
        {
            RuleFor(p => p.ConfigPath)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .Must(ValidateFileContent)
               .WithMessage("Config file must be empty.");

            RuleFor(p => p.NumberOfPlayers)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidateNumberOfPlayersIsNotTwo)
                .WithMessage("initial number of players must be 2.");
        }

        private bool ValidateFileContent(string configPath)
        {
            return String.IsNullOrEmpty(File.ReadAllText(configPath));
        }

        private bool ValidateNumberOfPlayersIsNotTwo(int numberOfPlayers)
        {
            return numberOfPlayers != 2;
        }

    }
}
