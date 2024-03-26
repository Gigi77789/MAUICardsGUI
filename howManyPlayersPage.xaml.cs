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
            // Convert entered text to numbers
            bool isNumber = int.TryParse(NumberOfPlayers.Text, out int numberOfPlayers);

            //Check if the conversion to number is successful and the number is between 1 and 4
            if (isNumber && numberOfPlayers >= 1 && numberOfPlayers <= 4)
            {
                // Hide error message if input is valid
                ErrorMessageLabel.IsVisible = false;

                // Navigate to a new page and pass the number of players
                await Navigation.PushAsync(new NameOfPlayersPage(numberOfPlayers));
            }
            else
            {
                ErrorMessageLabel.IsVisible = true; 
            }
        }
      
    }

}
