using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientControllerLibrary.Urls
{
    public class GameUrls : Urls
    {
        public string NewGame { get; }
        public string UpdateGame { get; }
        public string StartRound { get; }
        public string ProcessRound { get; }

        public string GameById { get; }
        public string GameByName { get; }
        public string GetCardsAndStatuses { get; }
        public string GetCardsAndStatusForPlayer { get; }

        public string GameIsInProgress { get; set; }
        public string GameWinner { get; set; }

        public GameUrls()
        {
            this.NewGame = $"{ServerCommandIpAddress}/api/newgame";
            this.UpdateGame = $"{ServerCommandIpAddress}/api/updategame";
            this.StartRound = $"{ServerCommandIpAddress}/api/startround";
            this.ProcessRound = $"{ServerCommandIpAddress}/api/processround";

            this.GameById = $"{ServerQueryIpAddress}/api/gamebyid";
            this.GameByName = $"{ServerQueryIpAddress}/api/gamebyname";
            this.GetCardsAndStatuses = $"{ServerQueryIpAddress}/api/getcardsandstatuses";
            this.GetCardsAndStatusForPlayer = $"{ServerQueryIpAddress}/api/getcardsandstatusforplayer";

            this.GameIsInProgress = $"{ServerQueryIpAddress}/api/gameisinprogress";
            this.GameWinner = $"{ServerQueryIpAddress}/api/gamewinner";
        }
    }
}
