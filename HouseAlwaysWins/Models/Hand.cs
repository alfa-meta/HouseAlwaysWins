using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;



public class Hand : IHand
{
    public Guid _handId { get; private set; }
    public Card[] _cardsInHand { get; private set; }
    public int _handValue { get; private set; }
    public HandState _handState { get; private set; }

    private static IDealerService _ds;
    private static ICalculatorService _cs;

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
    }
}