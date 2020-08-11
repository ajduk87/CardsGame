using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServerQuery
{
    public interface IConfigurationService
    {
        List<Parameter> GetParameters();
    }
}
