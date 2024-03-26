using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MAUICardsGUI
{
    /// <summary>
    /// Represents an individual card in deck two ways: 
    /// ID string is two-character short name and name is full card name written out
    /// </summary>
    public class Card
    {
        public string ID;
        public string name; // Option 1: just store the name for each card alongside the ID
        public string ImagePath => GetImagePath(); // Use a method to dynamically obtain the image path

        public Card(string id, string name)
        {
            ID = id;
            this.name = name;
        }

        private string GetImagePath()
        {           
            var suit = ID.Last();  // Get the last character as suit
            var value = ID.Substring(0, ID.Length - 1);   /*Extract characters using Substring. 
                                                          * ID.Length - 1 means all characters 
                                                          * except the last character.*/
            var suitName = suit switch  /*The suit characters (C, D, H, S) are converted 
                                         * into complete suit names (clubs, diamonds, 
                                         * hearts,  spades) because the picture names are
                                         * complete suit names.*/
                                         /*https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
                                           https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements*/
            {
                'C' => "clubs",
                'D' => "diamonds",
                'H' => "hearts",
                'S' => "spades",
                _ => throw new Exception("Invalid card suit")
            };

            // For J, Q, K, A, use their letters directly.
            var formattedValue = value switch
            {
                "A" => "A",
                "K" => "K",
            "Q" => "Q",
            "J" => "J",
            _ => value.PadLeft(2, '0') /*Make sure the card value is in 
                                        * two - digit format.If it is less
                                        * than two digits,add 0 in front.
                                        * Same name as the picture */
            };
            return $"../Images/card_{suitName}_{formattedValue}.png";  /* Construct the path
                                                                        * of the image and
                                                                        * return this path*/

        }

        // Option 2: figure out what the name should be based on the ID
        // (only uncomment this code if you choose to use this INSTEAD OF the name property, for now)
        /// <summary>
        /// Example of other approach to card name. If using this approach, you would
        /// replace any reference to card.name with card.GetName(). Later in the course,
        /// you will learn how to create a "getter" that combines these two approaches.
        /// Note that a lot of the code in this method is just slightly modified from Deck.cs
        /// </summary>
        /// <returns>String containing full name of card, calculated from the ID</returns>
        public string GetName()
        {
            string cardLongName;
            string cardVal = ID.Remove(ID.Length - 1);
            switch (cardVal)
            {
                case "A":
                    cardLongName = "Ace of ";
                    break;
                case "J":
                    cardLongName = "Jack of ";
                    break;
                case "Q":
                    cardLongName = "Queen of ";
                    break;
                case "K":
                    cardLongName = "King of ";
                    break;
                default:
                    cardLongName = cardVal.ToString() + " of ";
                    break;
            }

            string cardSuit = ID.Remove(ID.Length);
            switch (cardSuit)
            {
                case "S":
                    cardLongName += "Spades";
                    break;
                case "H":
                    cardLongName += "Hearts";
                    break;
                case "C":
                    cardLongName += "Clubs";
                    break;
                case "D":
                    cardLongName += "Diamonds";
                    break;
            }

            return cardLongName;
        }

       
    }
}
