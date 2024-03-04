namespace MAUICardsGUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new ImagesViewModel();
        }

        private async void NewGame_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new howManyPlayersPage());
        }

    }

}
