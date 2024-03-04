
namespace MAUICardsGUI
{
    public partial class howManyPlayersPage : ContentPage
    {
        public howManyPlayersPage()
        {
            InitializeComponent();
        }

        private async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NameOfPlayersPage());
        }

    }
}