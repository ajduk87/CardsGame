using AutoMapper;
using CardsGameServer.ApplicationLayer.Dtoes;
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

            CreateMap<GameStepModel, GameStepDto>();
            CreateMap<GameRoundProcessModel, GameRoundProcessDto>();
        }


    }
}

