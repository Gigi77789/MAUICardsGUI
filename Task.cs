using Microsoft.Maui.Controls;

namespace MAUICardsGUI
{
    /// <summary>
    /// Tracks game state. 
    /// Replaces less reliable string-based tracking in original.
    /// </summary>
    public enum Task
    {
        GetNumberOfPlayers,
        GetNames,
        IntroducePlayers,
        PlayerTurn,
        CheckForEnd,
        AskPlayersIfContinue,
        GameOver
    }
}
