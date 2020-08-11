using CardsGameServer.ApplicationLayer.Dtoes;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Mappings;
using CardsGameServer.DomainLayer.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.ApplicationLayer.Services.GameServices
{
    public class GameAppService : BaseAppService, IGameAppService
    {
        private readonly IGameService gameService;

        public GameAppService(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void MakeNewGame(IEnumerable<GameDto> gameDtoes)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                IEnumerable<Game> games = this.dtoToEntityMapper.MapList<IEnumerable<GameDto>, IEnumerable<Game>>(gameDtoes);
                this.gameService.InsertGame(connection, games);
            }
        }
        public void ChangeExisitngGame(GameDto gameDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Create())
            {
                Game game = this.dtoToEntityMapper.Map<GameDto, Game>(gameDto);
                this.gameService.UpdateGame(connection, game);
            }
        }
    }
}
