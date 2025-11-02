using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;



public interface IHand
{
    Guid HandId { get; }
    Card[] CardsInHand { get; }
    int CardCount { get; }
    int HandValue { get; }
    HandState HandState { get; }
    Card[] AddCardToHand(Card card);
    void EmptyPlayersHand();
    int GetCardCount();
    Card[] GetAllCardsInHand();
    HandState GetHandState();
    HandState SetHandStateToEmpty();
    HandState SetHandStateToBlackjack();
    HandState SetHandStateToBust();
    HandState SetHandStateToLive();
    HandState SetHandStateToStand();
    HandState SetHandStateToSurrendered();
    HandState SetHandStateToResolved();
}