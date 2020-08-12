using CardsGameServer.ApplicationLayer.Extensions;
using CardsGameServer.DomainLayer.Entities.GamesEntities;
using CardsGameServer.DomainLayer.Entities.PlayerEntities;
using CardsGameServer.DomainLayer.Entities.ValueObjects;
using CardsGameServer.DomainLayer.Repositories;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGameServer.DomainLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        private readonly ITableService tableService;

        public PlayerService(ITableService tableService)
        {
            this.playerRepository = Factory.Create<IPlayerRepository>();

            this.tableService = tableService;
        }


        public void PickWinningCards(IEnumerable<Player> allplayers, IEnumerable<GameStep> gameSteps)
        {
            int winnerId = gameSteps.Single(gameStep => gameStep.IsStepWinner == true).PlayerId;
            Player winner = allplayers.Where(player => player.Id == winnerId).Single();
            List<Card> winningCards = this.tableService.GetCardsFromTable();
            winner.DiscardPile.AddCardsToPile(winningCards);
        }
    }
}
