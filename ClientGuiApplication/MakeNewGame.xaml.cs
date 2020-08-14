using ClientControllerLibrary;
using ClientControllerLibrary.Dtoes.Game;
using ClientControllerLibrary.Dtoes.Player;
using ClientControllerLibrary.Urls;
using Newtonsoft.Json;
using RestSharp;
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
    /// Interaction logic for MakeNewGame.xaml
    /// </summary>
    public partial class MakeNewGame : UserControl
    {
        private readonly PlayerUrls playerUrls;
        private readonly GameUrls gameUrls;

        private readonly IApiCaller apiCaller;

        private int enteredPlayers = 0;
        private List<GameDto> gameDtoes = new List<GameDto>();
        private IEnumerable<PlayerDto> playerDtoes = new List<PlayerDto>();

        public MakeNewGame()
        {
            InitializeComponent();

            this.playerUrls = new PlayerUrls();
            this.gameUrls = new GameUrls();

            this.apiCaller = new ApiCaller();

            string responseMessage = this.apiCaller.Get(this.playerUrls.AllPlayers);
            string response = Regex.Unescape(responseMessage).Trim('"');
            playerDtoes = JsonConvert.DeserializeObject<IEnumerable<PlayerDto>>(response);
            IEnumerable<int> playerIds = playerDtoes.Select(playerDto => playerDto.Id);

            this.cmbPlayerId.ItemsSource = playerIds;
            this.cmbPlayerId.SelectedIndex = 0;

            this.tfplayername.Text = playerDtoes.First().Name;
        }

        private void BtnBeginTheGame_Click(object sender, RoutedEventArgs e)
        {
            IRestResponse response = this.apiCaller.Post(this.gameUrls.NewGame, gameDtoes);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Now you can go to tab Card game! Enjoy!");
            }
        }


        private void BtnEnterPlayer_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(cmbPlayerId.SelectedValue.ToString(), out int playerId);
            GameDto gameDto = new GameDto
            {
                Name = tfgamename.Text,
                NumberOfPlayers = Constants.NumberOfPlayers,
                PlayerId = playerId,
                PlayerName = tfplayername.Text
            };

            gameDtoes.Add(gameDto);

            enteredPlayers++;
            if (enteredPlayers == Constants.NumberOfPlayers)
            {
                btnEnterPlayer.IsEnabled = false;
            }
        }

        private void CmbPlayerId_SelectionChanged(object sender, SelectionChangedEventArgs e) =>
            tfplayername.Text = playerDtoes.Where(playerDto => playerDto.Id.ToString()
                                                                           .Equals(cmbPlayerId.SelectedValue
                                                                                              .ToString()))
                                                                                              .Single()
                                                                                              .Name;

    }
}
