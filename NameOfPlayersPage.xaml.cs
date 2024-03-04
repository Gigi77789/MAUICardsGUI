namespace MAUICardsGUI;

public partial class NameOfPlayersPage : ContentPage
{
	public NameOfPlayersPage()
	{
		InitializeComponent();
	}
    private async void Next_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePlayersPage());
    }
}