using CardsGameServer.ApplicationLayer.Enums;
using CardsGameServer.ApplicationLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Validation.Game
{
    public class RoundStartValidator : AbstractValidator<IEnumerable<PlayerStatusModel>>
    {
        private readonly int maxNumberOfPlayers = 4;
        private readonly int correctCardNumbers = 40;

        private readonly IDatabaseConnectionFactory databaseConnectionFactory;

        public RoundStartValidator()
        {
            this.databaseConnectionFactory = new DatabaseConnectionFactory();


            RuleFor(playerStatuses => playerStatuses)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .Must(ValidateCardSuit)
                 .WithMessage(playerStatuses => GetMessageForCardSuit(GetBagIndexesForCardSuit(playerStatuses)))
                 .Must(ValidateCardNumbers)
                 .WithMessage("Number of cards must be 40.")
                 .Must(ValidatePlayerNumbers)
                 .WithMessage("Number of players can't be greater than 4.");

        }

        #region whole messages

        private string GetMessageForCardSuit(string message)
        {
            return $"Non existing card suit for indexes [{message}].";
        }

        #endregion

        #region bad indexes part messages

        private string GetBagIndexesForCardSuit(IEnumerable<PlayerStatusModel> playerStatuses)
        {
            IEnumerable<int> badindexes = playerStatuses.Where(playerStatus => !Enum.IsDefined(typeof(CardSuit), playerStatus)).Select((playerStatus, index) => index).ToList();
            return String.Join(", ", badindexes);
        }

        #endregion

        #region validators

        private bool ValidateCardSuit(IEnumerable<PlayerStatusModel> playerStatuses)
        {
            return !playerStatuses.Any(playerStatus => !Enum.IsDefined(typeof(CardSuit), playerStatus));
        }

        private bool ValidateCardNumbers(IEnumerable<PlayerStatusModel> playerStatuses)
        {
            double cardNumbers = playerStatuses.Sum(playerStatus => playerStatus.CardsLeft);
            return cardNumbers == correctCardNumbers;
        }

        private bool ValidatePlayerNumbers(IEnumerable<PlayerStatusModel> playerStatuses)
        {
            return playerStatuses.Count() > this.maxNumberOfPlayers;
        }

        #endregion

    }
}
