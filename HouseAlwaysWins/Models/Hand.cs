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
        CardCount += 1;
        return CardsInHand.Append(card).ToArray();
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