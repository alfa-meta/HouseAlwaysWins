namespace HouseAlwaysWins.Models;

// Do not change the Order, Unit tests are bound to the order
// Example being Ace of Spades being the first card in the queue
// King of Hearts being the last card in the queue.
public enum Suit
{
    Spades, Clubs, Diamonds, Hearts
}

// Total 13 ranks.
public enum Rank
{
    Ace, Two, Three, Four, Five, Six, Seven,
    Eight, Nine, Ten, Jack, Queen, King
}

// record was chosen over struct due to being passed by reference.
// Class was not chosen to keep complexity down.
public record Card(Suit suit, Rank rank);