using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities.GamesEntities;

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
        }

        private bool MapIsWinnerProperty(bool? IsWinner)
        {
            return IsWinner.HasValue ? true : false;
        }
    }
}