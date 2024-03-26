namespace MAUICardsGUI;

public partial class GamePage : ContentPage
{
    private Deck deck = new Deck();

    private Player player1 = new Player("Player#1");
    private Player player2 = new Player("Player#2");
    private Player player3 = new Player("Player#3");
    private Player player4 = new Player("Player#4");

    private Game game;
    //public PlayerStatus status = PlayerStatus.active;

    public GamePage(List<string> playerNames)
    {
        InitializeComponent();
        game = new Game(new CardTable());
        deck.Shuffle();

        var players = new List<Player> { player1, player2, player3, player4 };
        var playerLabels = new List<Label> { player1Name, player2Name, player3Name, player4Name };
        var playerLayouts = new List<VerticalStackLayout> { player1Layout, player2Layout, player3Layout, player4Layout };

        // all invisible first
        foreach (var layout in playerLayouts)
        {
            layout.IsVisible = false;
        }

        // Assign names to players and make the layouts visible
        for (int i = 0; i < playerNames.Count; i++)
        {
            if (!string.IsNullOrWhiteSpace(playerNames[i]))
            {
                players[i].Name = playerNames[i]; // Assign the name from the input list to the player
                playerLabels[i].Text = playerNames[i];
                playerLayouts[i].IsVisible = true;
            }
        }
    }

    private void PlayerHitClicked(Player player, Label cardLabel, Label statusLabel, Image cardImage)
    {
        /*This method accepts a player object as parameters along with the tags and images associated 
      * with that player. Then, I modify each specific click event handler method so that they call
      * this general method and pass the corresponding parameters to it*/
        if (player.status == PlayerStatus.active)
        {
            var card = deck.DealTopCard();
            player.cards.Add(card);
            game.ScoreHand(player);
            UpdatePlayerCardDisplay(player, cardLabel, statusLabel);
            cardImage.Source = ImageSource.FromFile(card.ImagePath);

        }
    }

    private void Player1HitClicked(object sender, EventArgs e)
    {
        PlayerHitClicked(player1, player1CardLabel, player1StatusLabel, player1CardImage);
    }

    private void Player2HitClicked(object sender, EventArgs e)
    {
        PlayerHitClicked(player2, player2CardLabel, player2StatusLabel, player2CardImage);
    }

    private void Player3HitClicked(object sender, EventArgs e)
    {
        PlayerHitClicked(player3, player3CardLabel, player3StatusLabel, player3CardImage);
    }

    private void Player4HitClicked(object sender, EventArgs e)
    {
        PlayerHitClicked(player4, player4CardLabel, player4StatusLabel, player4CardImage);
    }

    private void Player1StayClicked(object sender, EventArgs e)
    {

    }
    private void Player2StayClicked(object sender, EventArgs e)
    {

    }
    private void Player3StayClicked(object sender, EventArgs e)
    {

    }
    private void Player4StayClicked(object sender, EventArgs e)
    {

    }





    private async void UpdatePlayerCardDisplay(Player player, Label cardLabel, Label statusLabel)
    {
        // Renew player's status
        player.UpdateScoreAndStatus();

        // Update card display
        cardLabel.Text = $"{string.Join(", ", player.cards.Select(c => c.name))} = {player.score} / 21";

        int activePlayerCount = 0;
        Player lastActivePlayer = null;
        string message = "";

        // Check how many players are not bust
        foreach (var p in new[] { player1, player2, player3, player4 })
        {
            if (p.status == PlayerStatus.active)
            {
                activePlayerCount++;
                lastActivePlayer = p; // Keep track of the last active player
            }
        }

        // Update status label based on game state
        if (activePlayerCount == 1 && lastActivePlayer.status != PlayerStatus.bust)
        {
            lastActivePlayer.status = PlayerStatus.win;
            statusLabel.Text = "Win!";
            message = $"{lastActivePlayer.Name} wins! Do you want to continue or exit?";
        }
        else if (player.status == PlayerStatus.bust)
        {
            statusLabel.Text = "Bust!";
            if (activePlayerCount == 0) // All players are bust
            {
                message = "All players are bust. Do you want to continue or exit?";
            }
        }
        else if (player.status == PlayerStatus.win)
        {
            statusLabel.Text = "Win!";
            message = $"{player.Name} wins! Do you want to continue or exit?";
        }
        else
        {
            statusLabel.Text = "";
        }

        // If a game-ending condition has been met, display an alert
        if (!string.IsNullOrEmpty(message))
        {
            bool answer = await DisplayAlert("Game Over", message, "Continue", "Exit");
            if (answer)
            {
                await Navigation.PushAsync(new howManyPlayersPage());
            }
            else
            {
                // Logic to exit the game: Close the application's current window
                var currentWindow = Application.Current.Windows.FirstOrDefault();
                if (currentWindow != null)
                {
                    Application.Current.CloseWindow(currentWindow);
                }
            }
        }
    }
    private void UpdatePlayer1CardDisplay(Player player)
    {
        UpdatePlayerCardDisplay(player, player1CardLabel, player1StatusLabel);
    }

    private void UpdatePlayer2CardDisplay(Player player)
    {
        UpdatePlayerCardDisplay(player, player2CardLabel, player2StatusLabel);
    }

    private void UpdatePlayer3CardDisplay(Player player)
    {
        UpdatePlayerCardDisplay(player, player3CardLabel, player3StatusLabel);
    }

    private void UpdatePlayer4CardDisplay(Player player)
    {
        UpdatePlayerCardDisplay(player, player4CardLabel, player4StatusLabel);
    }




}
