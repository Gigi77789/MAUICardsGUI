namespace MAUICardsGUI;

public partial class WelcomePlayersPage : ContentPage
{
	public WelcomePlayersPage()
	{
		InitializeComponent();
	}
    private async void Next_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddACardPage());
    }
}