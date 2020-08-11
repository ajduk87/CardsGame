using CardsGameServer.ApplicationLayer.Dtoes;
using System.Collections.Generic;

namespace CardsGameServer.ApplicationLayer.Services.Configuration
{
    public interface IConfigurationService
    {
        List<Parameter> GetParameters();
    }
}