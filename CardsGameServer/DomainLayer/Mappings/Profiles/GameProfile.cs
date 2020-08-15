using AutoMapper;
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
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PlayerName));

            CreateMap<PlayerStatusDto, GameStep>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GameStepId))
              .ForMember(dest => dest.IsStepWinner, opt => opt.MapFrom(src => new IsStepWinner(false)));
        }

        private bool MapIsWinnerProperty(bool? IsWinner)
        {
            return IsWinner.HasValue ? true : false;
        }
    }
}