namespace HouseAlwaysWins.Models;

/// <summary>
/// Represents the possible states of Blackjack Hand.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item><description><b>Empty</b> - No cards in hand.</description></item>
/// <item><description><b>BlackJack</b> – Ace + 10.</description></item>
/// <item><description><b>Bust</b> – Total hand value over 21.</description></item>
/// <item><description><b>Live</b> – Total hand value under 21; player can still make moves.</description></item>
/// <item><description><b>Stand</b> – Player stands with current hand until round ends.</description></item>
/// <item><description><b>Surrendered</b> – Player forfeits hand for an automatic loss.</description></item>
/// <item><description><b>Resolved</b> – Round outcome determined (win/lose/push applied).</description></item>
/// </list>
/// </remarks>

public enum HandState
{
    Empty, BlackJack, Bust, Live, Stand, Surrendered, Resolved
}


/// <summary>
/// Represents the Resolved State of the hand.
/// Meaning whether or not the hand is Resolved until end of round.
/// </summary>
public enum ResolvedState
{
    NotResolved, Win, Lose, Draw
}