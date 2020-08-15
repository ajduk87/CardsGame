using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientControllerLibrary.Urls
{
    public class PlayerUrls : Urls
    {
        public string NewPlayer { get; }
        public string AllPlayers { get; }
        public string DrawCards { get; }
        public string PlayerById { get; }

        public PlayerUrls()
        {
            this.NewPlayer = $"{ServerCommandIpAddress}/api/newplayer";
            this.DrawCards = $"{ServerCommandIpAddress}/api/drawcards";
            this.AllPlayers = $"{ServerQueryIpAddress}/api/players";
            this.PlayerById = $"{ServerQueryIpAddress}/api/playerbyid";
        }
    }
}
