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

        public PlayerUrls()
        {
            this.NewPlayer = $"{ServerCommandIpAddress}/api/newplayer";
        }
    }
}
