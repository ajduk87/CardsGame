using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using CardsGameServer.DomainLayer.Services;
using CardsGameTests;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private TestBuilder testBuilder;


        [SetUp]
        public void Setup()
        {
            RepositoryFactory.Factory.Initialize(new RepositoryFactory.DbFactory(RepositoryFactory.Finder.FindRepositoryTypes("CardsGameServer")));

            testBuilder = new TestBuilder();
        }

        [Test, Order(1)]
        public void NewPileCardTest()
        {
            //Assert
            Assert.IsTrue(testBuilder.NewPile.Cards.Count == 40);
        }

        [Test, Order(2)]
        public void ShuffleTest()
        {
            //Act
            List<Card> shuffledCards = testBuilder.ShiffleService.Shiffle(testBuilder.NewPile);

            //Assert
            Assert.IsTrue(testBuilder.NewPile.Cards.First().Value != shuffledCards.First().Value);
        }

        [Test, Order(3)]
        public void DrawCardTest()
        {
            //Arange
            List<Card> cards = testBuilder.MakeCardsForShuffling();
            List<Player> players = testBuilder.MakePlayers();

            //Act
            IEnumerable<Player> playerWithShuffledCards = testBuilder.PlayerService.ShuffleCards(players);

            //Assert
            Assert.IsNotEmpty(playerWithShuffledCards.First().PlayingPile.Cards);
        }

        [Test, Order(4)]
        public void GotCardsInOneRoundTest()
        {
            //Arange
            List<GameStep> gameSteps = testBuilder.MakeGameStepFirstRound();

            //Act
            List<GameStep> evaulatedGameSteps = testBuilder.EvaulationService.Evaulate(gameSteps).ToList();

            //Assert
            Assert.IsTrue(evaulatedGameSteps[0].IsStepWinner);
        }

        [Test, Order(5)]
        public void GotFourCardsInTwoRoundTest()
        {
            //Arange

            Player roundWinner = testBuilder.MakePlayerWithEmptyDiscardPile();
            List<Player> players = testBuilder.MakePlayers();
            List<GameStep> gameSteps = testBuilder.MakeGameStepSecondRound();

            //Act
            testBuilder.CroupierService.CollectCardsForThisRoundFromPlayers(players);


            List<GameStep> evaulatedGameSteps = testBuilder.EvaulationService.Evaulate(gameSteps).ToList();
            if (evaulatedGameSteps.Any(step => step.IsStepWinner == true))
            {
                roundWinner = testBuilder.PlayerService.PickRoundWinner(players, evaulatedGameSteps);
            }
            else
            {
                testBuilder.Player1.TopCard = new Card(new CardValue(3), "Clubs");
                testBuilder.Player2.TopCard = new Card(new CardValue(2), "Hearts");

                gameSteps = testBuilder.MakeGameStepThirdRound();
            }

            //Act again
            testBuilder.CroupierService.CollectCardsForThisRoundFromPlayers(players);
            evaulatedGameSteps = testBuilder.EvaulationService.Evaulate(gameSteps).ToList();
            if (evaulatedGameSteps.Any(step => step.IsStepWinner == true))
            {
                roundWinner = testBuilder.PlayerService.PickRoundWinner(players, evaulatedGameSteps);
            }

            //Assert
            Assert.IsTrue(roundWinner.DiscardPile.Cards.Count == 4);
        }
    }
}