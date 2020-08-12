﻿using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Extensions;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Entities.ValueObjects.GameSteps;
using System.Collections.Generic;

namespace CardsGameServer.DomainLayer.Mappings.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameDto, Game>()
                .ForMember(dest => dest.IsWinner, opt => opt.MapFrom(src => MapIsWinnerProperty(src.IsWinner)));

            CreateMap<GameDto, GameProgress>()
                .ForMember(dest => dest.GameName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsInProgress, opt => opt.MapFrom(src => src != null));

            CreateMap<GameDto, Player>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PlayerId))
               .ForMember(dest => dest.Name, opt => opt.Ignore());

            CreateMap<PlayerStatusDto, GameStep>()
              .ForMember(dest => dest.PlayingPile, opt => opt.MapFrom(src => MakePlayingCards(src.PlayingPile)))
              .ForMember(dest => dest.DiscardPile, opt => opt.MapFrom(src => MakeDiscardCards(src.DiscardPile)))
              .ForMember(dest => dest.IsStepWinner, opt => opt.MapFrom(src => new IsStepWinner(false)));
        }

        private List<Card> ConvertCardsContentToCards(string cardsContent)
        {
            List<Card> cards = new List<Card>();

            if (string.IsNullOrEmpty(cardsContent))
            {
                return cards;
            }

            IEnumerable<string> cardsRepresentation = cardsContent.Split(',');

            cardsRepresentation.ForEach(cardRepresentation =>
            {
                string[] cardParts = cardRepresentation.Split(' ');
                int.TryParse(cardParts[0], out int value);
                Card card = new Card(new CardValue(value), cardParts[1]);
                cards.Add(card);
            });

            return cards;
        }

        private PlayingPile MakePlayingCards(string playingCardsContent)
        {
            List<Card> cards = ConvertCardsContentToCards(playingCardsContent);
            return new PlayingPile(cards);
        }

        private DiscardPile MakeDiscardCards(string discardCardsContent)
        {
            List<Card> cards = ConvertCardsContentToCards(discardCardsContent);
            return new DiscardPile(cards);
        }

        private bool MapIsWinnerProperty(bool? IsWinner)
        {
            return IsWinner.HasValue ? true : false;
        }
    }
}