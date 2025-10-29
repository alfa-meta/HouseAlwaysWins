using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;



public class Hand : IHand
{
    public Guid _handId { get; private set; }
    public Card[] _cardsInHand { get; private set; }
    public int _handValue { get; private set; }
    public HandState _handState { get; private set; }

    private IDealerService _ds;
    private ICalculatorService _cs;

    public Hand(IDealerService dealerService, ICalculatorService calculatorService)
    {
        _handId = Guid.NewGuid();
        _cardsInHand = Array.Empty<Card>();
        _handValue = 0;
        _handState = HandState.Empty;

        _ds = dealerService;
        _cs = calculatorService;
    }

    public int CalculateHandValue()
    {
        _handState = EvaluateHandState();
        int _handValue = _cs.EvaluateHand(this);
        return _handValue;
    }

    public int GetCardCount()
    {
        return _cardsInHand.Count();
    }

    public void AddCardToHand(Card card)
    {
        _cardsInHand.Append(card);
        CalculateHandValue();
    }

    public void EmptyPlayersHand()
    {
        _cardsInHand = Array.Empty<Card>();
        _handState = HandState.Empty;
        _handValue = 0;
    }

    public HandState EvaluateHandState()
    {
        if (_handValue == 0 || _cardsInHand.Count() == 0)
        {
            _handState = SetHandStateToEmpty();
        }

        if (_handValue > 21)
        {
            _handState = SetHandStateToEmpty();
        }

        if (_handValue == 21 && _cardsInHand.Count() == 2)
        {
            _handState = SetHandStateToBlackjack();
        }
        
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