using ClientControllerLibrary;
using ClientControllerLibrary.Dtoes.Configuration;
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
    /// Interaction logic for CardGameSetup.xaml
    /// </summary>
    public partial class CardGameSetup : UserControl
    {

        private readonly PlayerUrls playerUrls;
        private readonly ConfigurationUrls configurationUrls;

        private readonly IApiCaller apiCaller;

        public CardGameSetup()
        {
            InitializeComponent();

            this.playerUrls = new PlayerUrls();
            this.configurationUrls = new ConfigurationUrls();

            this.apiCaller = new ApiCaller();

            string responseMessageStorage = this.apiCaller.Get(this.configurationUrls.Configuration);
            string responseStorage = Regex.Unescape(responseMessageStorage).Trim('"');
            PlayerNumberDto playerNumberDto = JsonConvert.DeserializeObject<PlayerNumberDto>(responseStorage);
            Constants.NumberOfPlayers = playerNumberDto.NumberOfPlayers;


            tfplayersnumber.Text = Constants.NumberOfPlayers.ToString();
        }

        private void BtnEnterPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerDto playerDto = new PlayerDto
            {
                Name = tffirstname.Text,
                MiddleName = tfmiddlename.Text,
                LastName = tflastname.Text
            };

            this.apiCaller.Post(this.playerUrls.NewPlayer, playerDto);
        }

        private void BtnSendToServer_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tfplayersnumber.Text, out int playernumber);

            PlayerNumberDto playerNumberDto = new PlayerNumberDto
            {
                NumberOfPlayers = playernumber
            };

            this.apiCaller.Put(this.configurationUrls.Configuration, playerNumberDto);
        }
    }
}
