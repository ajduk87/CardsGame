using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Entities.ValueObjects.Shared;
using CardsGameServer.DomainLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardsGameTests
{
    public class TestBuilder
    {
        public NewPile NewPile { get; set; }
        public IShiffleService ShiffleService { get; set; }
        public ITableService TableService { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IEvaulationService EvaulationService { get; set; }
        public ICroupierService CroupierService { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public TestBuilder()
        {
            this.NewPile = new NewPile();
            this.ShiffleService = new ShiffleService();
            this.TableService = new TableServiceForTests();
            this.EvaulationService = new EvaulationService();
            this.PlayerService = new PlayerService(this.TableService, this.ShiffleService);
            this.CroupierService = new CroupierService(this.TableService);

            List<Card> cards = new List<Card>()
            {
                new Card(new CardValue(8), "Clubs")
            };

            Player1 = new Player
            {
                Id = new Id(1),
                Name = new Name("Nikola"),
                PlayingPile = new PlayingPile(),
                DiscardPile = new DiscardPile(cards),
                TopCard = new Card(new CardValue(8), "Clubs")
            };

            Player2 = new Player
            {
                Id = new Id(2),
                Name = new Name("Ivan"),
                PlayingPile = new PlayingPile(),
                DiscardPile = new DiscardPile(),
                TopCard = new Card(new CardValue(8), "Hearts")
            };
        }

        public List<Card> MakeCardsForShuffling()
        {
            return new List<Card>
            {
                new Card(new CardValue(1), "Hearts"),
                new Card(new CardValue(2), "Clubs"),
                new Card(new CardValue(3), "Spades"),
                new Card(new CardValue(4), "Diamonds")
            };
        }

        public List<Player> MakePlayers()
        {

            return new List<Player>()
            {
                Player1,
                Player2
            };
        }

        public List<GameStep> MakeGameStepFirstRound()
        {
            return new List<GameStep>
            {
                new GameStep
                {
                    PlayerId = new Id(1),
                    CardValue = new CardValue(8),
                    CardSuit = new CardSuit("Clubs"),
                    IsStepWinner = new IsStepWinner(false),
                    CardsLeft = new CardsLeft(19)
                },
                new GameStep
                {
                    PlayerId = new Id(2),
                    CardValue = new CardValue(6),
                    CardSuit = new CardSuit("Hearts"),
                    IsStepWinner = new IsStepWinner(false),
                    CardsLeft = new CardsLeft(19)
                }
            };
        }

        public List<GameStep> MakeGameStepSecondRound()
        {
            return new List<GameStep>
            {
                new GameStep
                {
                    PlayerId = new Id(1),
                    CardValue = new CardValue(8),
                    CardSuit = new CardSuit("Clubs"),
                    IsStepWinner = new IsStepWinner(false),
                    CardsLeft = new CardsLeft(19)
                },
                new GameStep
                {
                    PlayerId = new Id(2),
                    CardValue = new CardValue(8),
                    CardSuit = new CardSuit("Hearts"),
                    IsStepWinner = new IsStepWinner(false),
                    CardsLeft = new CardsLeft(19)
                }
            };
        }

        public List<GameStep> MakeGameStepThirdRound()
        {
            return new List<GameStep>
            {
                new GameStep
                {
                    PlayerId = new Id(1),
                    CardValue = new CardValue(3),
                    CardSuit = new CardSuit("Clubs"),
                    IsStepWinner = new IsStepWinner(false),
                    CardsLeft = new CardsLeft(19)
                },
                new GameStep
                {
                    PlayerId = new Id(2),
                    CardValue = new CardValue(8),
                    CardSuit = new CardSuit("Hearts"),
                    IsStepWinner = new IsStepWinner(false),
                    CardsLeft = new CardsLeft(19)
                }
            };
        }

        public Player MakePlayerWithEmptyDiscardPile()
        {
            return new Player
            {
                DiscardPile = new DiscardPile()
            };
        }
    }
}
