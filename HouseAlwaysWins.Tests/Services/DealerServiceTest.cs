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
    private readonly Queue<Card> _testDeck;
    private readonly int _deterministicSeedValue = 7;

    public DealerServiceTest(ITestOutputHelper output)
    {
        _outputHelper = output;
        _testDeck = ds.CreateFullDeck();
    }

    [Fact]
    public void TwoDecksAreTheSame()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        Queue<Card> testDeck2 = ds.CreateFullDeck();

        Assert.Equal(testDeck, testDeck2);
    }

    [Fact]
    public void SuccessfullFullDeck52Count()
    {     
        bool deckCardCount = _testDeck.Count == 52;

        _outputHelper.WriteLine($"Correct - deckCardCount: {deckCardCount}");
        _outputHelper.WriteLine($"Bottom Card of the Deck: {_testDeck.Last().ToString()}");
        
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
    public void SuccessCountAllSuits()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        Card[] heartArray = Array.Empty<Card>();
        Card[] diamondArray = Array.Empty<Card>();
        Card[] clubsArray = Array.Empty<Card>();
        Card[] spadesArray = Array.Empty<Card>();

        Dictionary<Suit, int> counts = testDeck
            .GroupBy(c => c.suit)
            .ToDictionary(g => g.Key, g => g.Count());

        Assert.Equal(13, counts[Suit.Hearts]);
        Assert.Equal(13, counts[Suit.Diamonds]);
        Assert.Equal(13, counts[Suit.Clubs]);
        Assert.Equal(13, counts[Suit.Spades]);
    }

    [Fact]
    public void SuccesssCountAllRanks()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        
        Dictionary<Rank, int> counts = testDeck
            .GroupBy(c => c.rank)
            .ToDictionary(g => g.Key, g => g.Count());
        
        Assert.Equal(4, counts[Rank.Ace]);
        Assert.Equal(4, counts[Rank.Two]);
        Assert.Equal(4, counts[Rank.Three]);
        Assert.Equal(4, counts[Rank.Four]);
        Assert.Equal(4, counts[Rank.Five]);
        Assert.Equal(4, counts[Rank.Six]);
        Assert.Equal(4, counts[Rank.Seven]);
        Assert.Equal(4, counts[Rank.Eight]);
        Assert.Equal(4, counts[Rank.Nine]);
        Assert.Equal(4, counts[Rank.Ten]);
        Assert.Equal(4, counts[Rank.Jack]);
        Assert.Equal(4, counts[Rank.Queen]);
        Assert.Equal(4, counts[Rank.King]);
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
        Queue<Card> testDeckEmpty = ds.CreateEmptyDeck();

        int preTestDeckFullCount = _testDeck.Count();
        int preTestDeckEmptyCount = testDeckEmpty.Count();

        Queue<Card> testDeckFull = ds.EmptyDeck(ds.CreateFullDeck());
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
        int preTestDeckCount = _testDeck.Count();
        Queue<Card> testDeck = ds.EmptyDeck(ds.CreateFullDeck());
        testDeck.Enqueue(new Card(Suit.Spades, Rank.Ace));

        int testDeckCount = testDeck.Count();
        _outputHelper.WriteLine($"The Deck Should be empty - Number of Cards: {testDeckCount}");

        Assert.Equal(52, preTestDeckCount);
        Assert.Equal(1, testDeckCount);
    }


    [Fact]
    public void FailedShuffleDeckRandom()
    {
        Queue<Card> testDeck1 = ds.CreateFullDeck();

        testDeck1 = ds.ShuffleDeck(testDeck1, 0);
        Queue<Card> testDeck2 = ds.ShuffleDeck(ds.CreateFullDeck(), 0);

        Assert.NotEqual(testDeck1, testDeck2);
    }

    [Fact]
    public void SuccessShuffleDeckRandom()
    {
        foreach (Card card in _testDeck)
        {
            _outputHelper.WriteLine($"Test Card: {card}");
        }

        Queue<Card> testShuffledDeck = ds.ShuffleDeck(ds.CreateFullDeck(), 0);

        foreach (Card card in testShuffledDeck)
        {
            _outputHelper.WriteLine($"Shuffled Card: {card}");
        }

        Queue<Card> testShuffledDeck2 = ds.ShuffleDeck(ds.CreateFullDeck(), _deterministicSeedValue);

        Assert.NotEqual(_testDeck, testShuffledDeck);
        Assert.NotEqual(_testDeck, testShuffledDeck2);
        Assert.NotEqual(testShuffledDeck, testShuffledDeck2);
    }

    [Fact]
    public void FailedShuffleDeckSeeded()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        
    }

    [Fact]
    public void SuccessShuffleDeckSeeded()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
    }

    [Fact]
    public void FailedShuffleDeckEmpty()
    {
        Queue<Card> testEmptyDeck = ds.CreateEmptyDeck();
        testEmptyDeck = ds.ShuffleDeck(testEmptyDeck, 0);

        Assert.Empty(testEmptyDeck);

    
        testEmptyDeck.Enqueue(new Card(Suit.Spades, Rank.Two));

        Assert.NotEmpty(testEmptyDeck);
    }

    [Fact]
    public void SuccessPickACardFromTheTop()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        Card pickedCard = ds.PickACardFromTheTop(testDeck);

        _outputHelper.WriteLine($"Top Card of the Deck: {pickedCard.ToString()}");

        Assert.Equal(Suit.Spades, pickedCard.suit);
        Assert.Equal(Rank.Ace, pickedCard.rank);
    }

    [Fact]
    public void FailedPickACardFromTheTop()
    {
        Queue<Card> testDeck = ds.CreateEmptyDeck();
        Assert.Empty(testDeck);
        Assert.Throws<InvalidOperationException>(() => ds.PickACardFromTheTop(testDeck));
    }

    [Fact]
    public void SuccessPickACardFromTheBottom()
    {
        Queue<Card> testDeck = ds.CreateFullDeck();
        Card pickedCard = ds.PickACardFromTheBottom(testDeck);

        _outputHelper.WriteLine($"Top Card of the Deck: {pickedCard.ToString()}");

        Assert.Equal(Suit.Hearts, pickedCard.suit);
        Assert.Equal(Rank.King, pickedCard.rank);
    }
    
    [Fact]
    public void FailedPickACardFromTheBottom()
    {
        Queue<Card> testDeck = ds.CreateEmptyDeck();
        Assert.Empty(testDeck);
        Assert.Throws<InvalidOperationException>(() => ds.PickACardFromTheBottom(testDeck));
    }
}
