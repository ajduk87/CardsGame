using CardsGameServer.ApplicationLayer.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Services.PlayerServices
{
    public interface IPlayerAppServices
    {
        void EnterPlayer(PlayerDto playerDto);
        void DrawCards(IEnumerable<DrawCardDto> drawCardsDtoes);
    }
}
