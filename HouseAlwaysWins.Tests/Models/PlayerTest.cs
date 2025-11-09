using Xunit;
using Xunit.Abstractions;
using HouseAlwaysWins.Models;
using HouseAlwaysWins.Services;
using System.ComponentModel.DataAnnotations;

namespace HouseAlwaysWins.Tests;

public class PlayerTest
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly ICalculatorService _calculatorService;

    public PlayerTest(ITestOutputHelper output)
    {
        _outputHelper = output;
        _calculatorService = new CalculatorService();
    }

    [Fact]
    public void SuccessCorrectPlayer()
    {
        IPlayer testPlayer = new Player(_calculatorService);

        Assert.Equal(0, testPlayer.GetCardCountInHand());
        Assert.Empty(testPlayer.GetAllCards());
        Assert.Equal(HandState.Empty, testPlayer.EvaluateHandState());
    }

    [Fact]
    public void SuccessAddCardToHand()
    {
        IPlayer testPlayer = new Player(_calculatorService);

        testPlayer.AddCardToHand(new Card(Suit.Diamonds, Rank.Three));

        Assert.Equal(1, testPlayer.GetCardCountInHand());
        Assert.Single(testPlayer.GetAllCards());
        Assert.Equal(Suit.Diamonds, testPlayer.GetAllCards()[0].suit);
        Assert.Equal(Rank.Three, testPlayer.GetAllCards()[0].rank);
        Assert.Equal(HandState.Live, testPlayer.EvaluateHandState());
    }
}