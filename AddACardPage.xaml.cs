namespace MAUICardsGUI;

public partial class AddACardPage : ContentPage
{
	public AddACardPage()
	{
		InitializeComponent();
	}
    private async void Yes_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AfterAddingCardPage());
    }
}