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
        // Create a list containing all "Entry"
        var entries = new List<Entry> { NamesOfPlayers1, NamesOfPlayers2, NamesOfPlayers3, NamesOfPlayers4 };

        // Determine if all visible "Entry" are filled out
        bool allVisibleEntriesFilled = entries.Where(entry => entry.IsVisible)
                                               .All(entry => !string.IsNullOrWhiteSpace(entry.Text));
        /*Use Where to filter to filter out all Entries whose IsVisible property is true from the 
         * entries collection, and perform subsequent operations on the visible Entry controls
         * https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/filtering-data.*/

        // If all visible Entries are filled in..
        if (allVisibleEntriesFilled)
        {
            // Create a list of filled in names
            var playerNames = entries.Where(entry => entry.IsVisible)
                                     .Select(entry => entry.Text.Trim())
                                     .ToList();

            // Navigate to the GamePage, passing the list of player names
            await Navigation.PushAsync(new GamePage(playerNames));
        }
        else
        {
            // If at least one visible Entry is empty, display an error message
            ErrorMessageLabel.IsVisible = true;
        }
    }

}
