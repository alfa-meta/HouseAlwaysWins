using Xunit;
using Xunit.Abstractions;
using HouseAlwaysWins.Models;
using HouseAlwaysWins.Services;
using System.ComponentModel.DataAnnotations;

namespace HouseAlwaysWins.Tests;

public class DealerServiceTest
{
    private IDealerService ds = new DealerService();
    private readonly ITestOutputHelper _outputHelper;


    public DealerServiceTest(ITestOutputHelper output)
    {
        _outputHelper = output;
    }

    [Fact]
    public void SuccessfullFullDeck52Count()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        
        bool deckCardCount = testDeck.Count == 52;

        _outputHelper.WriteLine($"Correct - deckCardCount: {deckCardCount}");
        _outputHelper.WriteLine($"Bottom Card of the Deck: {testDeck.Last().ToString()}");
        
        Assert.True(deckCardCount);
    }

    [Fact]
    public void FailedFullDeck52Count()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        
        bool deckCardCount = testDeck.Count == 42;
        
        _outputHelper.WriteLine($"Incorrect - deckCardCount: {deckCardCount}");

        Assert.False(deckCardCount);
    }

    [Fact]
    public void SuccessNoDuplicatesFoundInDeck()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        HashSet<Card> cardHashSet = new HashSet<Card>();
        
        bool checkedQueue = testDeck.All(i => cardHashSet.Add(new Card(i.suit, i.rank)));
       
        _outputHelper.WriteLine($"Correct - Are there no duplicates?: {checkedQueue}");
        
        Assert.True(checkedQueue);
    }

    [Fact]
    public void FailedNoDuplicatesFoundInDeck()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        testDeck.Enqueue(new Card(Suit.Spades, Rank.Two));
        HashSet<Card> cardHashSet = new HashSet<Card>();

        bool checkedQueue = testDeck.All(i => cardHashSet.Add(new Card(i.suit, i.rank)));

        _outputHelper.WriteLine($"Correct - Are there no duplicates?: {checkedQueue}");
       
        Assert.False(checkedQueue);
    }

    [Fact]
    public void SucceedCreateEmptyDeck()
    {
        Queue<Card> emptyDeck = ds.CreateEmptyDeck();
        
        bool numberOfCardsIsZero = emptyDeck.Count == 0;
        
        _outputHelper.WriteLine($"Incorrect - Number of Cards is more than zero: {numberOfCardsIsZero}");
        
        Assert.True(numberOfCardsIsZero);
    }

    [Fact]
    public void FailedCreateEmptyDeck()
    {
        Queue<Card> emptyDeck = ds.CreateEmptyDeck();
        emptyDeck.Enqueue(new Card(Suit.Spades, Rank.Ace));

        bool numberOfCardsIsZero = emptyDeck.Count == 0;

        _outputHelper.WriteLine($"Incorrect - Number of Cards is more than zero: {numberOfCardsIsZero}");

        Assert.False(numberOfCardsIsZero);
    }

    [Fact]
    public void SuccessEmptyADeck()
    {
        Queue<Card> testDeckFull = ds.CreateFullDeck();
        Queue<Card> testDeckEmpty = ds.CreateEmptyDeck();

        int preTestDeckFullCount = testDeckFull.Count();
        int preTestDeckEmptyCount = testDeckEmpty.Count();

        testDeckFull = ds.EmptyDeck(testDeckFull);
        testDeckEmpty = ds.EmptyDeck(testDeckEmpty);

        int postTestDeckFullCount = testDeckFull.Count();
        int postTestDeckEmptyCount = testDeckEmpty.Count();

        _outputHelper.WriteLine($"preTestDeckFullCount: {preTestDeckFullCount} vs postTestDeckFullCount: {postTestDeckFullCount}");            
        _outputHelper.WriteLine($"preTestDeckEmptyCount: {preTestDeckEmptyCount} vs postTestDeckEmptyCount: {postTestDeckEmptyCount}");

        Assert.Equal(52, preTestDeckFullCount);
        Assert.Empty(testDeckEmpty);
        Assert.Empty(testDeckFull);
    }

    [Fact]
    public void FailedEmptyADeck()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        int preTestDeckCount = testDeck.Count();
        testDeck = ds.EmptyDeck(testDeck);
        testDeck.Enqueue(new Card(Suit.Spades, Rank.Ace));

        int testDeckCount = testDeck.Count();
        _outputHelper.WriteLine($"The Deck Should be empty - Number of Cards: {testDeckCount}");

        Assert.Equal(52, preTestDeckCount);
        Assert.Equal(1, testDeckCount);
    }

    [Fact]
    public void FailedShuffleDeck()
    {

    }

    [Fact]
    public void SuccessShuffleDeck()
    {

    }

    [Fact]
    public void SuccessPickACardFromTheTop()
    {


        // _outputHelper.WriteLine($"Top Card of the Deck: {testDeck.Dequeue().ToString()}");
    }

    [Fact]
    public void FailedPickACardFromTheTop()
    {

    }

    [Fact]
    public void SuccessPickACardFromTheBottom()
    {

    }
    
    [Fact]
    public void FailedPickACardFromTheBottom()
    {
        
    }
}
