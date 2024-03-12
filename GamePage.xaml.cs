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
        game = new Game(new CardTable()); // 假设你有一个合适的CardTable实例
        game.AddPlayer("Player#1"); // 示例中只处理一个玩家
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
            game.ScoreHand(player1); // 更新玩家分数
            UpdatePlayer1CardDisplay(player1); // 更新UI显示
  
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

    private void UpdatePlayer1CardDisplay(Player player1)
    {
        // 检查其他玩家是否都爆牌
        bool allOtherPlayersBust = (player4.status == PlayerStatus.bust) &&
                                    (player2.status == PlayerStatus.bust) &&
                                    (player3.status == PlayerStatus.bust);

        // 更新玩家4的分数和状态
        player1.UpdateScoreAndStatus();

        // 更新UI显示
        player1CardLabel.Text = $"{string.Join(", ", player1.cards.Select(c => c.name))} = {player1.score} / 21";

        // 如果玩家4爆牌，显示"Bust!"
        if (player1.status == PlayerStatus.bust)
        {
            player1StatusLabel.Text = "Bust!";
        }
        // 如果其他玩家都爆牌，将玩家4的状态设置为胜利，并显示"Win!"
        else if (allOtherPlayersBust)
        {
            player1.status = PlayerStatus.win;
            player1StatusLabel.Text = "Win!";
        }
        // 如果玩家4已经赢得比赛，显示"Win!"
        else if (player1.status == PlayerStatus.win)
        {
            player1StatusLabel.Text = "Win!";
        }
        // 其他情况下清空状态信息
        else
        {
            player1StatusLabel.Text = "";
        }
    }



    private void UpdatePlayer2CardDisplay(Player player2)
    {
        // 检查其他玩家是否都爆牌
        bool allOtherPlayersBust = (player1.status == PlayerStatus.bust) &&
                                    (player3.status == PlayerStatus.bust) &&
                                    (player4.status == PlayerStatus.bust);

        // 更新玩家4的分数和状态
        player2.UpdateScoreAndStatus();

        // 更新UI显示
        player2CardLabel.Text = $"{string.Join(", ", player2.cards.Select(c => c.name))} = {player2.score} / 21";

        // 如果玩家4爆牌，显示"Bust!"
        if (player2.status == PlayerStatus.bust)
        {
            player2StatusLabel.Text = "Bust!";
        }
        // 如果其他玩家都爆牌，将玩家4的状态设置为胜利，并显示"Win!"
        else if (allOtherPlayersBust)
        {
            player2.status = PlayerStatus.win;
            player2StatusLabel.Text = "Win!";
        }
        // 如果玩家4已经赢得比赛，显示"Win!"
        else if (player2.status == PlayerStatus.win)
        {
            player2StatusLabel.Text = "Win!";
        }
        // 其他情况下清空状态信息
        else
        {
            player2StatusLabel.Text = "";
        }
    }

    private void UpdatePlayer3CardDisplay(Player player3)
    {
        // 检查其他玩家是否都爆牌
        bool allOtherPlayersBust = (player1.status == PlayerStatus.bust) &&
                                    (player2.status == PlayerStatus.bust) &&
                                    (player4.status == PlayerStatus.bust);

        // 更新玩家4的分数和状态
        player3.UpdateScoreAndStatus();

        // 更新UI显示
        player3CardLabel.Text = $"{string.Join(", ", player3.cards.Select(c => c.name))} = {player3.score} / 21";

        // 如果玩家4爆牌，显示"Bust!"
        if (player3.status == PlayerStatus.bust)
        {
            player3StatusLabel.Text = "Bust!";
        }
        // 如果其他玩家都爆牌，将玩家4的状态设置为胜利，并显示"Win!"
        else if (allOtherPlayersBust)
        {
            player3.status = PlayerStatus.win;
            player3StatusLabel.Text = "Win!";
        }
        // 如果玩家4已经赢得比赛，显示"Win!"
        else if (player3.status == PlayerStatus.win)
        {
            player3StatusLabel.Text = "Win!";
        }
        // 其他情况下清空状态信息
        else
        {
            player3StatusLabel.Text = "";
        }
    }

    private void UpdatePlayer4CardDisplay(Player player4)
    {
        // 检查其他玩家是否都爆牌
        bool allOtherPlayersBust = (player1.status == PlayerStatus.bust) &&
                                    (player2.status == PlayerStatus.bust) &&
                                    (player3.status == PlayerStatus.bust);

        // 更新玩家4的分数和状态
        player4.UpdateScoreAndStatus();

        // 更新UI显示
        player4CardLabel.Text = $"{string.Join(", ", player4.cards.Select(c => c.name))} = {player4.score} / 21";

        // 如果玩家4爆牌，显示"Bust!"
        if (player4.status == PlayerStatus.bust)
        {
            player4StatusLabel.Text = "Bust!";
        }
        // 如果其他玩家都爆牌，将玩家4的状态设置为胜利，并显示"Win!"
        else if (allOtherPlayersBust)
        {
            player4.status = PlayerStatus.win;
            player4StatusLabel.Text = "Win!";
        }
        // 如果玩家4已经赢得比赛，显示"Win!"
        else if (player4.status == PlayerStatus.win)
        {
            player4StatusLabel.Text = "Win!";
        }
        // 其他情况下清空状态信息
        else
        {
            player4StatusLabel.Text = "";
        }
    }


}