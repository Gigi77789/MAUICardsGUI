using Microsoft.Maui.Controls;

namespace MAUICardsGUI
{	
	/// <summary>
	/// Class representing individual player:
	/// name, cards in hand, score (sum of current card values), status (from enum PlayerStatus)
	/// </summary>
	public class Player
	{
		public string name;
        public string Name { get; set; }
        public List<Card> cards = new List<Card>();
		public PlayerStatus status = PlayerStatus.active;
		public int score;

		public Player(string n)
		{
			name = n;
        }

        public void UpdateScoreAndStatus()
        {
            score = cards.Sum(card =>
            {
                int cardScore = 0;
                if (card.ID.StartsWith("A"))
                {
                    cardScore = 1;
                }
                else if ("JQK".Contains(card.ID[0]))
                {
                    cardScore = 10;
                }
                else
                {
                    cardScore = int.Parse(card.ID.Substring(0, card.ID.Length - 1));
                }
                return cardScore;
            });

            if (score > 21)
            {
                status = PlayerStatus.bust;
            }
            else if (score == 21)
            {
                status = PlayerStatus.win; 
            }
        }




        /// <summary>
        /// Introduces player by name. Called by CardTable object.
        /// </summary>
        /// <param name="playerNum"></param>
        public void Introduce(int playerNum)
		{
			Console.WriteLine("Hello, my name is " + name + " and I am player #" + playerNum);
		}
	}
}

