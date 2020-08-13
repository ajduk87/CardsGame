using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.ApplicationLayer.Enums;
using CardsGameServer.ApplicationLayer.Models;

namespace CardsGameServer.ApplicationLayer.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateModel, GameDto>();
            CreateMap<GameUpdateModel, GameDto>();
        }
    }
}