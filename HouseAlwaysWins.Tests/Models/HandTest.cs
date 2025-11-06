using Xunit;
using Xunit.Abstractions;
using HouseAlwaysWins.Models;
using System.ComponentModel.DataAnnotations;

namespace HouseAlwaysWins.Tests;

public class HandTest
{

    private readonly ITestOutputHelper _outputHelper;
    private static Card testCardKingOfClubs = new Card(Suit.Clubs, Rank.King);
    private static Card testCardThreeOfDiamonds = new Card(Suit.Diamonds, Rank.Three);
    public HandTest(ITestOutputHelper output)
    {
        _outputHelper = output;
    }

    [Fact]
    public void SuccessHandInitialisation()
    {
        IHand testHand = new Hand();
        var testHandId = testHand.HandId;

        Assert.Equal(typeof(Guid), testHandId.GetType());
        Assert.Empty(testHand.GetAllCardsInHand());
        Assert.Equal(0, testHand.GetCardCount());
        Assert.Equal(0, testHand.HandValue);
        Assert.Equal(HandState.Empty, testHand.HandState);
    }

    [Fact]
    public void SuccessAddCardToHand()
    {
        IHand testHand = new Hand();
        Assert.Equal(HandState.Empty, testHand.GetHandState());

        Card[] testCardArray = testHand.AddCardToHand(testCardKingOfClubs);

        Assert.NotEmpty(testCardArray);
        Assert.Equal(HandState.Live, testHand.GetHandState());
        Assert.Equal(testCardKingOfClubs.GetType(), testCardArray[0].GetType());
        Assert.Equal(Suit.Clubs, testCardArray[0].suit);
        Assert.Equal(Rank.King, testCardArray[0].rank);

        Assert.NotEqual(Rank.Ace, testCardArray[0].rank);
        Assert.NotEqual(Suit.Spades, testCardArray[0].suit);
    }

    [Fact]
    public void SuccessAddMultipleCardsToHand()
    {
        IHand testHand = new Hand();

        Card[] testCardArray = testHand.AddCardToHand(testCardKingOfClubs);
        testHand.AddCardToHand(testCardThreeOfDiamonds);
        Card[] testAllCardsFromHand = testHand.GetAllCardsInHand();

        _outputHelper.WriteLine(string.Join(", ", testAllCardsFromHand.Select(c => $"{c.rank} of {c.suit}")));

        Assert.Single(testCardArray);
        Assert.Equal(2, testHand.GetCardCount());
        Assert.Equal(Suit.Clubs, testAllCardsFromHand[0].suit);
        Assert.Equal(Rank.King, testAllCardsFromHand[0].rank);
        Assert.Equal(Suit.Diamonds, testAllCardsFromHand[1].suit);
        Assert.Equal(Rank.Three, testAllCardsFromHand[1].rank);
    }

    [Fact]
    public void SuccessHandIsEmpty()
    {
        IHand testEmptyHand = new Hand();

        Assert.Equal(HandState.Empty, testEmptyHand.GetHandState());
        Assert.Empty(testEmptyHand.GetAllCardsInHand());
    }
    
    [Fact]
    public void FailedHandIsEmpty()
    {
        IHand testEmptyHand = new Hand();
        testEmptyHand.AddCardToHand(testCardKingOfClubs);

        Assert.Equal(HandState.Live, testEmptyHand.GetHandState());
        Assert.NotEqual(0, testEmptyHand.GetAllCardsInHand().Count());
    }
}