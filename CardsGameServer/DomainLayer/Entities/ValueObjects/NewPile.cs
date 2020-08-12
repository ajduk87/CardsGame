using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Entities.ValueObjects
{
    public class NewPile : ValueObject<NewPile>, IPile
    {
        public List<Card> Cards { get; }


        public NewPile()
        {
            this.Cards = new List<Card>
            {
                new Card(new CardValue(1), "Clubs"),
                new Card(new CardValue(2), "Clubs"),
                new Card(new CardValue(3), "Clubs"),
                new Card(new CardValue(4), "Clubs"),
                new Card(new CardValue(5), "Clubs"),
                new Card(new CardValue(6), "Clubs"),
                new Card(new CardValue(7), "Clubs"),
                new Card(new CardValue(8), "Clubs"),
                new Card(new CardValue(9), "Clubs"),
                new Card(new CardValue(10), "Clubs"),

                new Card(new CardValue(1), "Diamonds"),
                new Card(new CardValue(2), "Diamonds"),
                new Card(new CardValue(3), "Diamonds"),
                new Card(new CardValue(4), "Diamonds"),
                new Card(new CardValue(5), "Diamonds"),
                new Card(new CardValue(6), "Diamonds"),
                new Card(new CardValue(7), "Diamonds"),
                new Card(new CardValue(8), "Diamonds"),
                new Card(new CardValue(9), "Diamonds"),
                new Card(new CardValue(10), "Diamonds"),

                new Card(new CardValue(1), "Hearts"),
                new Card(new CardValue(2), "Hearts"),
                new Card(new CardValue(3), "Hearts"),
                new Card(new CardValue(4), "Hearts"),
                new Card(new CardValue(5), "Hearts"),
                new Card(new CardValue(6), "Hearts"),
                new Card(new CardValue(7), "Hearts"),
                new Card(new CardValue(8), "Hearts"),
                new Card(new CardValue(9), "Hearts"),
                new Card(new CardValue(10), "Hearts"),

                new Card(new CardValue(1), "Spades"),
                new Card(new CardValue(2), "Spades"),
                new Card(new CardValue(3), "Spades"),
                new Card(new CardValue(4), "Spades"),
                new Card(new CardValue(5), "Spades"),
                new Card(new CardValue(6), "Spades"),
                new Card(new CardValue(7), "Spades"),
                new Card(new CardValue(8), "Spades"),
                new Card(new CardValue(9), "Spades"),
                new Card(new CardValue(10), "Spades")
            };
        }
    }
}
