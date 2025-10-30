using Xunit;
using Xunit.Abstractions;
using HouseAlwaysWins.Models;
using HouseAlwaysWins.Services;
using System.ComponentModel.DataAnnotations;

namespace HouseAlwaysWins.Tests;

public class CalculatorServiceTest
{
    private ICalculatorService cs = new CalculatorService();

    private IDealerService ds = new DealerService();

    private readonly ITestOutputHelper _outputHelper;

    private readonly Queue<Card> _testDeck;

    public CalculatorServiceTest(ITestOutputHelper output)
    {
        _outputHelper = output;
        _testDeck = ds.CreateFullDeck();
    }


    [Fact]
    public void SuccessEmptyHand()
    {
        Queue<Card> testDeck = ds.CreateEmptyDeck();
        IPlayer player1 = new Player();

        Assert.Equal(0, player1.GetCardCountInHand());
    }

    // TODO 
    [Fact]
    public void SuccessAddCardToHandForPlayer()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        IPlayer player1 = new Player();
        Card testDequeuedCard = testDeck.Dequeue();
        player1.AddCardToHand(testDequeuedCard);

        Card testCard = new Card(Suit.Spades, Rank.Ace);
        Card[] testPlayerHandCards = player1.GetAllCards();

        _outputHelper.WriteLine(testPlayerHandCards.Count().ToString());

        Assert.Equal(1, player1.GetCardCountInHand());
        // Assert.Equal(testCard, testPlayerHandCards[0]);
    }
}