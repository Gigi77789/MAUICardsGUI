namespace MAUICardsGUI;

public partial class NameOfPlayersPage : ContentPage
{
	public NameOfPlayersPage(int numberOfPlayers)
	{
		InitializeComponent();
        SetPlayerEntriesVisibility(numberOfPlayers);

    }

    private void SetPlayerEntriesVisibility(int numberOfPlayers)
    {
        //Add the Entries to a list and control their visibility based on the number of players.
        var entries = new List<Entry> { NamesOfPlayers1, NamesOfPlayers2, NamesOfPlayers3, NamesOfPlayers4};

        for (int i = 0; i < numberOfPlayers; i++)
        {
            entries[i].IsVisible = true;
        }
    }

    private async void Next_Clicked(object sender, EventArgs e)
    {
        var playerNames = new List<string>
    {
        NamesOfPlayers1.Text,
        NamesOfPlayers2.Text,
        NamesOfPlayers3.Text,
        NamesOfPlayers4.Text
    };

        // delete the empty input
        playerNames = playerNames.Where(name => !string.IsNullOrWhiteSpace(name)).ToList();

        await Navigation.PushAsync(new GamePage(playerNames));
    }
}