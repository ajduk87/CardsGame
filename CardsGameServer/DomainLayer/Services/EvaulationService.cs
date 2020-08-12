using CardsGameServer.ApplicationLayer.Extensions;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public class EvaulationService : IEvaulationService
    {
        /***************** This is too procedural approach ***********************/

        /***************** It will be refactored in another branch ***********************/

        private List<GameStep> gameStepsEvaulating;

        private bool IsStaleMate(IEnumerable<GameStep> gameSteps)
        {
            List<int> cardValues = new List<int>();
            gameSteps.ForEach(gameStep => cardValues.Add(gameStep.CardValue));

            return cardValues.Distinct().Count() == 1;
        }

        private List<GameStep> EvaulateForMoreThanTwoPlayers(List<GameStep> gameSteps)
        {
            int numberOfPlayers = gameSteps.Count;

            gameSteps[0].IsStepWinner = new IsStepWinner(true);
            int stepWinnerCurrentIndex = 0;
            for (int i = 1; i < numberOfPlayers; i++)
            {
                if (gameSteps[i].CardValue > gameSteps[stepWinnerCurrentIndex].CardValue)
                {
                    gameSteps[stepWinnerCurrentIndex].IsStepWinner = new IsStepWinner(false);
                    stepWinnerCurrentIndex = i;
                    gameSteps[i].IsStepWinner = new IsStepWinner(true);
                }
            }

            return gameSteps;
        }

        private void CalculateCardLefts()
        {
            for (int i = 0; i < gameStepsEvaulating.Count; i++)
            {
                gameStepsEvaulating[i].CardsLeft = gameStepsEvaulating[i].IsStepWinner == true ?
                                                   new CardsLeft(gameStepsEvaulating[i].CardsLeft + 1) :
                                                   new CardsLeft(gameStepsEvaulating[i].CardsLeft - 1) ;
            }
        }


        private void WinnerBetweenTwoPlayers(IEnumerable<GameStep> gameSteps)
        {
            gameStepsEvaulating = gameSteps.ToList();

            if (IsStaleMate(gameSteps))
            {
                return;
            }

            if (gameStepsEvaulating[0].CardValue > gameStepsEvaulating[1].CardValue)
            {
                gameStepsEvaulating[0].IsStepWinner = new IsStepWinner(true);
            }
            else
            {
                gameStepsEvaulating[1].IsStepWinner = new IsStepWinner(true);
            }
        }

        private void WinnerBetweenThreePlayers(IEnumerable<GameStep> gameSteps)
        {
            List<GameStep> gameStepsForEvaulation = gameSteps.ToList();

            if (IsStaleMate(gameSteps))
            {
                return;
            }

            gameStepsForEvaulation = EvaulateForMoreThanTwoPlayers(gameStepsForEvaulation);
        }

        private void WinnerBetweenFourPlayers(IEnumerable<GameStep> gameSteps)
        {
            List<GameStep> gameStepsForEvaulation = gameSteps.ToList();

            if (IsStaleMate(gameSteps))
            {
                return;
            }
            gameStepsForEvaulation = EvaulateForMoreThanTwoPlayers(gameStepsForEvaulation);
        }


        public IEnumerable<GameStep> Evaulate(IEnumerable<GameStep> gameSteps)
        {
            int numbeOfPlayers = gameSteps.Count();

            switch (numbeOfPlayers)
            {
                case 3: WinnerBetweenThreePlayers(gameSteps); break;
                case 4: WinnerBetweenFourPlayers(gameSteps); break;
                default: WinnerBetweenTwoPlayers(gameSteps); break;
            }

            CalculateCardLefts();

            return gameStepsEvaulating;
        }
    }
}
