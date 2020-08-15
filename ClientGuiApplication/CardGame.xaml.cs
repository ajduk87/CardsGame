using ClientControllerLibrary;
using ClientControllerLibrary.Dtoes.Game;
using ClientControllerLibrary.Dtoes.Player;
using ClientControllerLibrary.Urls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientGuiApplication
{
    /// <summary>
    /// Interaction logic for CardGame.xaml
    /// </summary>
    public partial class CardGame : UserControl
    {
        private readonly GameUrls gameUrls;
        private readonly PlayerUrls playerUrls;

        private readonly IApiCaller apiCaller;

        private IEnumerable<PlayerStatusDto> playerStatusDtoes;
        private IEnumerable<PlayerRoundDto> playerRoundDtoes;


        public CardGame()
        {
            InitializeComponent();

            this.gameUrls = new GameUrls();
            this.playerUrls = new PlayerUrls();

            this.apiCaller = new ApiCaller();
        }

        private void ReadPlayerNewCardsAndStatuses()
        {

            foreach (var playerStatusDto in playerStatusDtoes)
            {
                string responseMessage = this.apiCaller.Get(this.playerUrls.PlayerById, new object[] { playerStatusDto.PlayerId });
                string response = Regex.Unescape(responseMessage).Trim('"');
                PlayerDto playerDto = JsonConvert.DeserializeObject<PlayerDto>(response);

                responseMessage = this.apiCaller.Get(this.gameUrls.GetCardsAndStatusForPlayer, new object[] { Params.GameName, Params.NumberOfPlayers, playerStatusDto.PlayerId });
                response = Regex.Unescape(responseMessage).Trim('"');
                PlayerStatusDto newStatus = JsonConvert.DeserializeObject<PlayerStatusDto>(response);

                string[] cardParts = playerDto.TopCard.Split(' ');
                int.TryParse(cardParts[0], out int cardValue);
                playerStatusDto.CardValue = cardValue;
                playerStatusDto.CardSuit = cardParts[1];
                playerStatusDto.PlayingPile = playerDto.PlayingPile;
                playerStatusDto.DiscardPile = playerDto.DiscardPile;
                playerStatusDto.CardsLeft = newStatus.CardsLeft;
                playerStatusDto.GameStepId = newStatus.GameStepId + Params.NumberOfPlayers;
            }
        }

        private void ReadPlayerCardsAndStatuses()
        {
            string responseMessage = this.apiCaller.Get(this.gameUrls.GetCardsAndStatuses, new object[] { Params.GameName, Params.NumberOfPlayers });
            string response = Regex.Unescape(responseMessage).Trim('"');
            playerStatusDtoes = JsonConvert.DeserializeObject<IEnumerable<PlayerStatusDto>>(response);
        }

        private int ConverterForCardSuit(string suit)
        {
            switch (suit)
            {
                case "Clubs": return 1;
                case "Diamonds": return 2;
                case "Hearts": return 3;
                case "Spades": return 4;
                default: return 0;
            }
        }

        private IEnumerable<PlayerRoundDto> GetPlayerRoundDtoes(IEnumerable<PlayerStatusDto> playerStatusDtoes, Func<string, int> converter)
        {
            List<PlayerRoundDto> playerRoundDtoes = new List<PlayerRoundDto>();

            playerStatusDtoes.ToList().ForEach(playerStatusDto =>
                                        {
                                            PlayerRoundDto playerRoundDto = new PlayerRoundDto
                                            {
                                                PlayerId = playerStatusDto.PlayerId,
                                                PlayerName = playerStatusDto.PlayerName,
                                                CardValue = playerStatusDto.CardValue,
                                                CardSuit = converter(playerStatusDto.CardSuit),
                                                PlayingPile = playerStatusDto.PlayingPile,
                                                DiscardPile = playerStatusDto.DiscardPile,
                                                CardsLeft = playerStatusDto.CardsLeft,
                                                GameStepId = playerStatusDto.GameStepId
                                            };
                                            playerRoundDtoes.Add(playerRoundDto);
                                        });

            return playerRoundDtoes;
        }

        private void PopulateTfs()
        {
            tfDiscardPile1.Text = $"{playerStatusDtoes.ElementAt(0).DiscardPile.Split(',').Length} cardsleft";
            tfPlayingPile1.Text = $"{playerStatusDtoes.ElementAt(0).PlayingPile.Split(',').Length} cardsleft";
            tfTopCard1.Text = $"{playerStatusDtoes.ElementAt(0).CardValue} {playerStatusDtoes.ElementAt(0).CardSuit}";
            tfDiscardPile2.Text = $"{playerStatusDtoes.ElementAt(1).DiscardPile.Split(',').Length} cardsleft";
            tfPlayingPile2.Text = $"{playerStatusDtoes.ElementAt(1).PlayingPile.Split(',').Length} cardsleft";
            tfTopCard2.Text = $"{playerStatusDtoes.ElementAt(1).CardValue} {playerStatusDtoes.ElementAt(0).CardSuit}";
        }

        private void BtnStartRound_Click(object sender, RoutedEventArgs e)
        {
            if (Params.NumberOfSteps == 0)
            {
                ReadPlayerCardsAndStatuses();
                PopulateTfs();
                return;
            }
            else
            {
                List<DrawCardDto> drawCardDtoes = new List<DrawCardDto>();
                foreach (var playerStatusDto in playerStatusDtoes)
                {
                    DrawCardDto drawCardDto = new DrawCardDto
                    {
                        PlayerId = playerStatusDto.PlayerId
                    };

                    drawCardDtoes.Add(drawCardDto);
                }

                this.apiCaller.Put(this.playerUrls.DrawCards, drawCardDtoes);

                ReadPlayerNewCardsAndStatuses();
                PopulateTfs();

                this.playerRoundDtoes = GetPlayerRoundDtoes(playerStatusDtoes, ConverterForCardSuit);

                this.apiCaller.Post(this.gameUrls.StartRound, playerRoundDtoes);
            }


        }

        private void BtnFinishRound_Click(object sender, RoutedEventArgs e)
        {
            this.playerRoundDtoes = GetPlayerRoundDtoes(playerStatusDtoes, ConverterForCardSuit);

            this.apiCaller.Post(this.gameUrls.ProcessRound, playerRoundDtoes);

            ReadPlayerCardsAndStatuses();
            PopulateTfs();

            if (IsGameOver())
            {
                string responseMessage = this.apiCaller.Get(this.gameUrls.GameWinner, new object[] { Params.GameName });
                string response = Regex.Unescape(responseMessage).Trim('"');
                GameWinnerDto gameGameWinnerDto = JsonConvert.DeserializeObject<GameWinnerDto>(response);

                MessageBox.Show($"Winner is {gameGameWinnerDto.PlayerName} in {Params.NumberOfSteps} numbers of steps.");
            }
            else
            {
                Params.NumberOfSteps++;
            }
        }

        private bool IsGameOver()
        {
            string responseMessage = this.apiCaller.Get(this.gameUrls.GameIsInProgress, new object[] { Params.GameName });
            string response = Regex.Unescape(responseMessage).Trim('"');
            GameProgressDto gameProgressDto = JsonConvert.DeserializeObject<GameProgressDto>(response);

            return !gameProgressDto.IsInProgress;
        }
    }
}
