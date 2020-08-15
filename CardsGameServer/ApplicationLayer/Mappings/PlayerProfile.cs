using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Enums;
using CardsGameServer.ApplicationLayer.Models;
using CardsGameServer.ApplicationLayer.Models.Player;

namespace CardsGameServer.ApplicationLayer.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerCreateModel, PlayerDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name));

            CreateMap<PlayerStatusModel, PlayerStatusDto>()
                .ForMember(dest => dest.CardSuit, opt => opt.MapFrom(src => ConvertCardSuit(src.CardSuit)));

            CreateMap<DrawCardModel, DrawCardDto>();
        }

        private string ConvertCardSuit(int cardSuit)
        {
            CardSuit suit = (CardSuit)cardSuit;
            return suit.ToString();
        }
    }
}
