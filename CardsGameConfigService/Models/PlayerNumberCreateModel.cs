using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameConfigService.Models
{
    public class PlayerNumberCreateModel : PlayerNumberBaseModel
    {
        public string ConfigPath { get; set; }
    }
}
