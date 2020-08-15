using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public class EvaulationService : IEvaulationService
    {
        private List<GameStep> gameStepsEvaulating;

        private bool IsStaleMate(IEnumerable<GameStep> gameSteps)
        {
            List<int> cardValues = new List<int>();
            gameSteps.ForEach(gameStep => cardValues.Add(gameStep.CardValue));

            return cardValues.Distinct().Count() == 1;
        }

        public IEnumerable<GameStep> Evaulate(IEnumerable<GameStep> gameSteps)
        {
            if (IsStaleMate(gameSteps))
            {
                return gameSteps;
            }

            int maxIndexStep = gameSteps.IndexOfMaxBy(step => step.CardValue);

            gameStepsEvaulating[maxIndexStep].IsStepWinner = new IsStepWinner(true);

            gameStepsEvaulating.ForEach(gameStepEv =>
                                        {
                                            gameStepEv.CardsLeft = gameStepEv.IsStepWinner == true ?
                                                   new CardsLeft(gameStepEv.CardsLeft + 1) :
                                                   new CardsLeft(gameStepEv.CardsLeft - 1);
                                        });

            return gameStepsEvaulating;
        }
    }
}
