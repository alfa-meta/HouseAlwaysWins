using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;

public class Hand : IHand
{
    private readonly ICalculatorService _calculatorService;
    public Guid HandId { get; private set; }
    public Card[] CardsInHand { get; private set; }
    public int CardCount { get; private set; }
    public int HandValue { get; private set; }
    public HandState HandState { get; private set; }
    public Hand(ICalculatorService calculatorService)
    {
        ArgumentNullException.ThrowIfNull(calculatorService);
        _calculatorService = calculatorService;

        HandId = Guid.NewGuid();
        CardsInHand = Array.Empty<Card>();
        CardCount = 0;
        HandValue = 0;
        HandState = HandState.Empty;
    }

    public Card[] AddCardToHand(Card card)
    {
        SetHandStateToLive();

        CardsInHand = CardsInHand.Append(card).ToArray();
        CardCount = CardsInHand.Length;
        HandValue = _calculatorService.EvaluateHand(this);
        return CardsInHand;
    }

    public void EmptyPlayersHand()
    {
        CardsInHand = Array.Empty<Card>();
        HandState = HandState.Empty;
        CardCount = 0;
        HandValue = 0;
    }

    public int GetCardCount() => CardCount;
    public Card[] GetAllCardsInHand() => CardsInHand;
    public HandState GetHandState() => HandState;

    public HandState SetHandStateToEmpty()
    {
        if (CardsInHand.Length > 0)
        {
            // Don't change HandState if Cards exist
            return HandState;
        }

        HandState = HandState.Empty;
        return HandState;
    }

    public HandState SetHandStateToBlackjack() { HandState = HandState.Blackjack; return HandState; }
    public HandState SetHandStateToBust() { HandState = HandState.Bust; return HandState; }
    public HandState SetHandStateToLive() { HandState = HandState.Live; return HandState; }
    public HandState SetHandStateToStand() { HandState = HandState.Stand; return HandState; }
    public HandState SetHandStateToSurrendered() { HandState = HandState.Surrendered; return HandState; }
    public HandState SetHandStateToResolved() { HandState = HandState.Resolved; return HandState; }
}