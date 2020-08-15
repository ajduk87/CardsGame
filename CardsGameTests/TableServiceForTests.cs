using CardsGameServer.ApplicationLayer.Extensions;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using CardsGameServer.DomainLayer.Repositories;
using CardsGameServer.DomainLayer.Services;
using RepositoryFactory;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CardsGameTests
{
    public class TableServiceForTests : ITableService
    {
        private readonly ITableSaver tableSaver;
        private string basePath = Path.Combine(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\..\CardsGameServer")), "Table");
        private string tablePath = string.Empty;

        public TableServiceForTests()
        {
            this.tableSaver = Factory.Create<ITableSaver>();
            this.tablePath = $"{this.basePath}\\table.txt";
        }

        private List<Card> ConvertCardsRepresentationToCards(IEnumerable<string> cardsRepresentation)
        {
            List<Card> cards = new List<Card>();

            cardsRepresentation.ForEach(cardRepresentation =>
            {
                string[] cardParts = cardRepresentation.Split(' ');
                int.TryParse(cardParts[0], out int value);
                Card card = new Card(new CardValue(value), cardParts[1]);
                cards.Add(card);
            });

            return cards;
        }

        public void PutOnTable(List<Card> cards)
        {
            List<string> cardsRepresentation = new List<string>();

            cards.ForEach(card =>
            {
                string cardRepresentation = card.ToString();
                cardsRepresentation.Add(cardRepresentation);
            });

            this.tableSaver.Save(this.tablePath, cardsRepresentation);
        }

        public List<Card> PeekOnTable()
        {
            IEnumerable<string> cardsRepresentation = this.tableSaver.Peek(this.tablePath);
            List<Card> cards = ConvertCardsRepresentationToCards(cardsRepresentation);
            return cards;
        }

        public List<Card> GetCardsFromTable()
        {
            IEnumerable<string> cardsRepresentation = this.tableSaver.GetOn(this.tablePath);
            List<Card> cards = ConvertCardsRepresentationToCards(cardsRepresentation);
            return cards;
        }
    }
}
