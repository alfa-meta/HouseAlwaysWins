using Xunit;
using Xunit.Abstractions;
using HouseAlwaysWins.Models;
using HouseAlwaysWins.Services;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace HouseAlwaysWins.Tests;

public class HandTest
{

    private readonly ITestOutputHelper _outputHelper;
    private readonly ICalculatorService _calculatorService;
    private static Card testCardKingOfClubs = new Card(Suit.Clubs, Rank.King);
    private static Card testCardThreeOfDiamonds = new Card(Suit.Diamonds, Rank.Three);
    public HandTest(ITestOutputHelper output)
    {
        _outputHelper = output;
        _calculatorService = new CalculatorService();
    }

    [Fact]
    public void SuccessHandInitialisation()
    {
        IHand testHand = new Hand(_calculatorService);
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
        IHand testHand = new Hand(_calculatorService);
        Assert.Equal(HandState.Empty, testHand.GetHandState());

        Card[] testCardArray = testHand.AddCardToHand(testCardKingOfClubs);

        Assert.NotEmpty(testCardArray);
        Assert.Equal(HandState.Live, testHand.GetHandState());
        Assert.Equal(testCardKingOfClubs.GetType(), testCardArray[0].GetType());
        Assert.Equal(Suit.Clubs, testCardArray[0].suit);
        Assert.Equal(Rank.King, testCardArray[0].rank);

        Assert.Equal(10, testHand.HandValue);

        Assert.NotEqual(Rank.Ace, testCardArray[0].rank);
        Assert.NotEqual(Suit.Spades, testCardArray[0].suit);
    }

    [Fact]
    public void SuccessAddMultipleCardsToHand()
    {
        IHand testHand = new Hand(_calculatorService);

        Card[] testCardArray = testHand.AddCardToHand(testCardKingOfClubs);
        Assert.Equal(10, testHand.HandValue);

        testHand.AddCardToHand(testCardThreeOfDiamonds);
        Card[] testAllCardsFromHand = testHand.GetAllCardsInHand();
        Assert.Equal(13, testHand.HandValue);

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
        IHand testEmptyHand = new Hand(_calculatorService);

        Assert.Equal(HandState.Empty, testEmptyHand.GetHandState());
        Assert.Empty(testEmptyHand.GetAllCardsInHand());
        Assert.Equal(0, testEmptyHand.HandValue);
    }

    [Fact]
    public void FailedHandIsEmpty()
    {
        IHand testEmptyHand = new Hand(_calculatorService);
        testEmptyHand.AddCardToHand(testCardKingOfClubs);

        Assert.Equal(HandState.Live, testEmptyHand.GetHandState());
        Assert.NotEmpty(testEmptyHand.GetAllCardsInHand());
    }

    [Fact]
    public void SuccessGetCorrectHandState()
    {
        IHand testHand = new Hand(_calculatorService);

        // Test Default state
        Assert.Equal(HandState.Empty, testHand.GetHandState());
        
        // Test Blackjack state
        testHand.SetHandStateToBlackjack();
        Assert.Equal(HandState.Blackjack, testHand.GetHandState());

        // Test Handstate Empty 
        testHand.SetHandStateToEmpty();
        Assert.Equal(HandState.Empty, testHand.GetHandState());

        // Test Handstate Bust
        testHand.SetHandStateToBust();
        Assert.Equal(HandState.Bust, testHand.GetHandState());

        // Test Handstate Stand
        testHand.SetHandStateToStand();
        Assert.Equal(HandState.Stand, testHand.GetHandState());

        // Test Handstate Surrendered
        testHand.SetHandStateToSurrendered();
        Assert.Equal(HandState.Surrendered, testHand.GetHandState());

        // Test Handstate Resolved
        testHand.SetHandStateToResolved();
        Assert.Equal(HandState.Resolved, testHand.GetHandState());

        // Test Handstate Live
        testHand.SetHandStateToLive();
        Assert.Equal(HandState.Live, testHand.GetHandState());
    }
}