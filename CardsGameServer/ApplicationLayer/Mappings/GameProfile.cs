using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Enums;
using CardsGameServer.ApplicationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateModel, GameDto>();
            CreateMap<GameUpdateModel, GameDto>();

            CreateMap<PlayerStatusModel, PlayerStatusDto>()
                .ForMember(dest => dest.CardSuit, opt => opt.MapFrom(src => ConvertCardSuit(src.CardSuit)));
        }

        private string ConvertCardSuit(int cardSuit)
        {
            CardSuit suit = (CardSuit)cardSuit;
            return suit.ToString();
        }
    }
}

