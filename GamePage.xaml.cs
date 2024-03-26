namespace MAUICardsGUI;

public partial class GamePage : ContentPage
{
    private Deck deck = new Deck();
    private Player player1 = new Player("Player#1");
    private Player player2 = new Player("Player#2");
    private Player player3 = new Player("Player#3");
    private Player player4 = new Player("Player#4");
    private Game game;
    public PlayerStatus status = PlayerStatus.active;

    public GamePage(List<string> playerNames)
    {
        InitializeComponent();
        game = new Game(new CardTable());
        game.AddPlayer("Player#1");
        deck.Shuffle();

        var playerLabels = new List<Label> { player1Name, player2Name, player3Name, player4Name };
        var playerLayouts = new List<VerticalStackLayout> { player1Layout, player2Layout, player3Layout, player4Layout };

        // all invisible first
        foreach (var layout in playerLayouts)
        {
            layout.IsVisible = false;
        }

        // shoe the content based on the number of the names and name itslef
        for (int i = 0; i < playerLabels.Count; i++)
        {
            if (i < playerNames.Count && !string.IsNullOrWhiteSpace(playerNames[i]))
            {
                playerLabels[i].Text = playerNames[i];
                playerLayouts[i].IsVisible = true;
            }
        }
    }

    private void Player1HitClicked(object sender, EventArgs e)
    {

        if (player1.status == PlayerStatus.active)
        {
            var card = deck.DealTopCard();
            player1.cards.Add(card);
            game.ScoreHand(player1); // renew players score
            UpdatePlayer1CardDisplay(player1);
            player1CardImage.Source = ImageSource.FromFile(card.ImagePath); // get images
        }
    }

    private void Player2HitClicked(object sender, EventArgs e)
    {
        if (player2.status == PlayerStatus.active)
        {
            var card = deck.DealTopCard();
            player2.cards.Add(card);
            game.ScoreHand(player2);
            UpdatePlayer2CardDisplay(player2);
            player2CardImage.Source = ImageSource.FromFile(card.ImagePath);
        }
    }

    private void Player3HitClicked(object sender, EventArgs e)
    {
        if (player3.status == PlayerStatus.active)
        {
            var card = deck.DealTopCard();
            player3.cards.Add(card);
            game.ScoreHand(player3);
            UpdatePlayer3CardDisplay(player3);
            player3CardImage.Source = ImageSource.FromFile(card.ImagePath);
        }
    }

    private void Player4HitClicked(object sender, EventArgs e)
    {
        if (player4.status == PlayerStatus.active)
        {
            var card = deck.DealTopCard();
            player4.cards.Add(card);
            game.ScoreHand(player4);
            UpdatePlayer4CardDisplay(player4);
            player4CardImage.Source = ImageSource.FromFile(card.ImagePath);
        }
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


  

    private void UpdatePlayer1CardDisplay(Player player1) //display the info aboout the player1
    {
        // check other players status
        bool allOtherPlayersBust = (player4.status == PlayerStatus.bust) &&
                                    (player2.status == PlayerStatus.bust) &&
                                    (player3.status == PlayerStatus.bust);
        // renew status
        player1.UpdateScoreAndStatus();

        player1CardLabel.Text = $"{string.Join(", ", player1.cards.Select(c => c.name))} = {player1.score} / 21";
        // LINQ expression used to select (Select) the name of each card (c.name) from all the cards of player 1: https://learn.microsoft.com/en-us/dotnet/csharp/linq/,https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/projection-operations
        if (allOtherPlayersBust)
        {
            player1.status = PlayerStatus.win;
            player1StatusLabel.Text = "Win!";
        }
    
        else if (player1.status == PlayerStatus.bust)
        {
            player1StatusLabel.Text = "Bust!";
        }

        else if (player1.status == PlayerStatus.win)
        {
            player1StatusLabel.Text = "Win!";
        }

        else
        {
            player1StatusLabel.Text = "";
        }
    }
    private void UpdatePlayer2CardDisplay(Player player2)
    {

        bool allOtherPlayersBust = (player1.status == PlayerStatus.bust) &&
                                    (player3.status == PlayerStatus.bust) &&
                                    (player4.status == PlayerStatus.bust);


        player2.UpdateScoreAndStatus();


        player2CardLabel.Text = $"{string.Join(", ", player2.cards.Select(c => c.name))} = {player2.score} / 21";


        if (allOtherPlayersBust)
        {
            player2.status = PlayerStatus.win;
            player2StatusLabel.Text = "Win!";
        }

        else if
         (player2.status == PlayerStatus.bust)
        {
            player2StatusLabel.Text = "Bust!";
        }
        else if (player2.status == PlayerStatus.win)
        {
            player2StatusLabel.Text = "Win!";
        }

        else
        {
            player2StatusLabel.Text = "";
        }
    }

    private void UpdatePlayer3CardDisplay(Player player3)
    {

        bool allOtherPlayersBust = (player1.status == PlayerStatus.bust) &&
                                    (player2.status == PlayerStatus.bust) &&
                                    (player4.status == PlayerStatus.bust);

        player3.UpdateScoreAndStatus();

        player3CardLabel.Text = $"{string.Join(", ", player3.cards.Select(c => c.name))} = {player3.score} / 21";

        if (allOtherPlayersBust)
        {
            player3.status = PlayerStatus.win;
            player3StatusLabel.Text = "Win!";
        }

        else if (player3.status == PlayerStatus.bust)
        {
            player3StatusLabel.Text = "Bust!";
        }

        else if (player3.status == PlayerStatus.win)
        {
            player3StatusLabel.Text = "Win!";
        }

        else
        {
            player3StatusLabel.Text = "";
        }
    }

    private void UpdatePlayer4CardDisplay(Player player4)
    {

        bool allOtherPlayersBust = (player1.status == PlayerStatus.bust) &&
                                    (player2.status == PlayerStatus.bust) &&
                                    (player3.status == PlayerStatus.bust);

        player4.UpdateScoreAndStatus();

        player4CardLabel.Text = $"{string.Join(", ", player4.cards.Select(c => c.name))} = {player4.score} / 21";

        if (allOtherPlayersBust)
        {
            player4.status = PlayerStatus.win;
            player4StatusLabel.Text = "Win!";
        }

        else if (player4.status == PlayerStatus.bust)
        {
            player4StatusLabel.Text = "Bust!";
        } 

        else if (player4.status == PlayerStatus.win)
        {
            player4StatusLabel.Text = "Win!";
        }

        else
        {
            player4StatusLabel.Text = "";
        }
    }


}
