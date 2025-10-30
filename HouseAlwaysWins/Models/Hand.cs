using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;

public class Hand : IHand
{
    public Guid _handId { get; private set; }
    public Card[] _cardsInHand { get; set; }
    public int _cardCount { get; set; }
    public int _handValue { get; set; }
    public HandState _handState { get;  set; }
    public Hand()
    {
        _handId = Guid.NewGuid();
        _cardsInHand = Array.Empty<Card>();
        _cardCount = 0;
        _handValue = 0;
        _handState = HandState.Empty;
    }

    public void AddCardToHand(Card card)
    {
        _cardsInHand.Append(card);
        _cardCount += 1;
    }

    public void EmptyPlayersHand()
    {
        _cardsInHand = Array.Empty<Card>();
        _handState = HandState.Empty;
        _cardCount = 0;
        _handValue = 0;
    }

    public int GetCardCount()
    {
        return _cardCount;
    }

    public Card[] GetAllCardsInHand()
    {
        return _cardsInHand;
    }

    public HandState GetHandState()
    {
        return _handState;
    }
    public HandState SetHandStateToEmpty()
    {
        return HandState.Empty;
    }

    public HandState SetHandStateToBlackjack()
    {
        return HandState.Blackjack;
    }

    public HandState SetHandStateToBust()
    {
        return HandState.Bust;
    }

    public HandState SetHandStateToLive()
    {
        return HandState.Live;
    }

    public HandState SetHandStateToStand()
    {
        return HandState.Stand;
    }

    public HandState SetHandStateToSurrendered()
    {
        return HandState.Surrendered;
    }

    public HandState SetHandStateToResolved()
    {
        return HandState.Resolved;
    }
}