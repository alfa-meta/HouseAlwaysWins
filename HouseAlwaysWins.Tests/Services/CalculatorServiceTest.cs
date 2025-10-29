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
        Queue<Card> testDeck = ds.CreateFullDeck;
        Player player1 = new Player();
        player1.hand;
    }
}