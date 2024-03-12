using Microsoft.Maui.Controls;

namespace MAUICardsGUI
{
    public partial class howManyPlayersPage : ContentPage
    {
        public howManyPlayersPage()
        {
            InitializeComponent();
        }

        private async void PlayerNumbersButton_Clicked(object sender, EventArgs e)
        {
           int numberOfPlayers = int.Parse(NumberOfPlayers.Text); 
           await Navigation.PushAsync(new NameOfPlayersPage(numberOfPlayers));
        }
      
    }

}
