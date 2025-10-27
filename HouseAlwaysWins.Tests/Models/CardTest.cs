using Xunit;
using HouseAlwaysWins.Models;

public class CardTests
{

    static Card TwoOfHearts = new Card(Suit.Hearts, Rank.Two);
    static Card AceOfSpades = new Card(Suit.Spades, Rank.Ace);

    [Fact]
    public void SuccessCorrectRank()
    {
        // Assert.NotEqual<T>(T expected, T actual)
        Assert.NotEqual(Rank.Three, TwoOfHearts.rank);
        Assert.Equal(Rank.Two, TwoOfHearts.rank);
    }

    [Fact]
    public void SuccessCorrectSuit()
    {
        // Negative check: suit is not Spades
        Assert.NotEqual(Suit.Spades, TwoOfHearts.suit);

        // (Optional stronger positive check)
        Assert.Equal(Suit.Hearts, TwoOfHearts.suit);
    }

}