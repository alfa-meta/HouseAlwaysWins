using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;

public class Hand : IHand
{
    public Guid HandId { get; private set; }
    public Card[] CardsInHand { get; set; }
    public int CardCount { get; set; }
    public int HandValue { get; set; }
    public HandState HandState { get;  set; }
    public Hand()
    {
        HandId = Guid.NewGuid();
        CardsInHand = Array.Empty<Card>();
        CardCount = 0;
        HandValue = 0;
        HandState = HandState.Empty;
    }

    public Card[] AddCardToHand(Card card)
    {
        this.SetHandStateToLive();

        CardsInHand = CardsInHand.Append(card).ToArray();
        CardCount = CardsInHand.Length;
        return CardsInHand;
    }

    public void EmptyPlayersHand()
    {
        CardsInHand = Array.Empty<Card>();
        HandState = HandState.Empty;
        CardCount = 0;
        HandValue = 0;
    }

    public int GetCardCount() 
    {
        return CardCount;
    }

    public Card[] GetAllCardsInHand()
    {
        return CardsInHand;
    }

    public HandState GetHandState()
    {
        return HandState;
    }
    public HandState SetHandStateToEmpty()
    {
        HandState = HandState.Empty;
        return HandState;
    }

    public HandState SetHandStateToBlackjack()
    {
        HandState = HandState.Blackjack;
        return HandState;
    }

    public HandState SetHandStateToBust()
    {
        HandState = HandState.Bust;
        return HandState;
    }

    public HandState SetHandStateToLive()
    {
        HandState = HandState.Live;
        return HandState;
    }

    public HandState SetHandStateToStand()
    {
        HandState = HandState.Stand;
        return HandState;
    }

    public HandState SetHandStateToSurrendered()
    {
        HandState = HandState.Surrendered;
        return HandState;
    }

    public HandState SetHandStateToResolved()
    {
        HandState = HandState.Resolved;
        return HandState;
    }
}