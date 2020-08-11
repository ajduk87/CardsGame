using CardsGameServer.ApplicationLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Validation.Game
{
    public class GameListCreateValidator : AbstractValidator<IEnumerable<GameCreateModel>>
    {
        private readonly int maxNumberOfPlayers = 4;

        public GameListCreateValidator()
        {
            RuleFor(game => game)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .Must(ValidateIsNameStartsWithGame)
                 .WithMessage(game => GetMessageForNameNotStartsWithGame(GetBagIndexesForNameNotStartsWithGame(game)))
                 .Must(ValidateNumberOfPlayersIsNotNegative)
                 .WithMessage(game => GetMessageForNumberOfPlayersIsNegative(GetBagIndexesForNumberOfPlayersIsNegative(game)))
                 .Must(ValidateNumberOfPlayersIsNotZero)
                 .WithMessage(game => GetMessageForNumberOfPlayersIsZero(GetBagIndexesForNumberOfPlayersIsZero(game)))
                 .Must(ValidateNumberOfPlayersIsNotOne)
                 .WithMessage(game => GetMessageForNumberOfPlayersIsOne(GetBagIndexesForNumberOfPlayersIsOne(game)))
                 .Must(ValidateMaxNumberOfPlayers)
                 .WithMessage(game => GetMessageForNumberOfPlayersGreaterThanFour(GetBagIndexesForNumberOfPlayersGreaterThanFour(game)));

            //validate is player exist


        }
        #region whole messages

        private string GetMessageForNameNotStartsWithGame(string message)
        {
            return $"Name of game must be start with word GAME for indexes [{message}].";
        }

        private string GetMessageForNumberOfPlayersIsNegative(string message)
        {
            return $"Number of players can't be negative for indexes [{message}].";
        }

        private string GetMessageForNumberOfPlayersIsZero(string message)
        {
            return $"Number of players can't be 0 for indexes [{message}].";
        }

        private string GetMessageForNumberOfPlayersIsOne(string message)
        {
            return $"Number of players can't be 1 for indexes [{message}].";
        }

        private string GetMessageForNumberOfPlayersGreaterThanFour(string message)
        {
            return $"Number of players can't be greater than 4 for indexes [{message}].";
        }

        #endregion

        #region bad indexes part messages

        private string GetBagIndexesForNameNotStartsWithGame(IEnumerable<GameCreateModel> games)
        {
            IEnumerable<int> badindexes = games.Where(game => !game.Name.StartsWith("game")).Select((game, index) => index).ToList();
            return String.Join(", ", badindexes);
        }

        private string GetBagIndexesForNumberOfPlayersIsNegative(IEnumerable<GameCreateModel> games)
        {
            IEnumerable<int> badindexes = games.Where(game => game.NumberOfPlayers < 0).Select((game, index) => index).ToList();
            return String.Join(", ", badindexes);
        }

        private string GetBagIndexesForNumberOfPlayersIsZero(IEnumerable<GameCreateModel> games)
        {
            IEnumerable<int> badindexes = games.Where(game => game.NumberOfPlayers == 0).Select((game, index) => index).ToList();
            return String.Join(", ", badindexes);
        }

        private string GetBagIndexesForNumberOfPlayersIsOne(IEnumerable<GameCreateModel> games)
        {
            IEnumerable<int> badindexes = games.Where(game => game.NumberOfPlayers == 1).Select((game, index) => index).ToList();
            return String.Join(", ", badindexes);
        }

        private string GetBagIndexesForNumberOfPlayersGreaterThanFour(IEnumerable<GameCreateModel> games)
        {
            IEnumerable<int> badindexes = games.Where(game => maxNumberOfPlayers < game.NumberOfPlayers).Select((game, index) => index).ToList();
            return String.Join(", ", badindexes);
        }

        #endregion

        #region validators

        private bool ValidateIsNameStartsWithGame(IEnumerable<GameCreateModel> games)
        {
            return !games.Any(game => !game.Name.StartsWith("game"));
        }

        private bool ValidateNumberOfPlayersIsNotNegative(IEnumerable<GameCreateModel> games)
        {
            return !games.Any(game => (game.NumberOfPlayers < 0));
        }

        private bool ValidateNumberOfPlayersIsNotZero(IEnumerable<GameCreateModel> games)
        {
            return !games.Any(game => (game.NumberOfPlayers == 0));
        }

        private bool ValidateNumberOfPlayersIsNotOne(IEnumerable<GameCreateModel> games)
        {
            return !games.Any(game => (game.NumberOfPlayers == 1));
        }

        private bool ValidateMaxNumberOfPlayers(IEnumerable<GameCreateModel> games)
        {
            return !games.Any(game => (maxNumberOfPlayers < game.NumberOfPlayers));
        }

        # endregion
    }
}
