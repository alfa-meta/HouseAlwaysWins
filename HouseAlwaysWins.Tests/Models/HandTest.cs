using Xunit;
using Xunit.Abstractions;
using HouseAlwaysWins.Models;
using System.ComponentModel.DataAnnotations;

namespace HouseAlwaysWins.Tests;

public class HandTest
{

    private readonly ITestOutputHelper _outputHelper;

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
        Assert.Empty(testHand.CardsInHand);
        Assert.Equal(0, testHand.GetCardCount());
        Assert.Equal(0, testHand.HandValue);
        Assert.Equal(HandState.Empty, testHand.HandState);
    }

    [Fact]
    public void SuccessEmptyHand()
    {

    }
    
    [Fact]
    public void FailedEmptyHand()
    {
        
    }
}