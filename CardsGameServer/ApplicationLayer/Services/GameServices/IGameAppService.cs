﻿using CardsGameServer.ApplicationLayer.Dtoes;
using System.Collections.Generic;

namespace CardsGameServer.ApplicationLayer.Services.GameServices
{
    public interface IGameAppService
    {
        void MakeNewGame(IEnumerable<GameDto> gameDtoes);
        void ChangeExisitngGame(GameDto gameDto);
        void StartRound(IEnumerable<PlayerStatusDto> playerStatusDtoes);
        void ProcessRound(IEnumerable<PlayerStatusDto> playerStatusDtoes);
    }
}