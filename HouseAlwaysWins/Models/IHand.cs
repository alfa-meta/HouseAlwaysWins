using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;



public interface IHand
{
    Guid _handId { get; }
    Card[] _cardsInHand { get; }
    int _handValue { get; }
    HandState _handState { get; }
    void AddCardToHand(Card card);
    void EmptyPlayersHand();
    HandState EvaluateHandState();
    HandState SetHandStateToEmpty();
    HandState SetHandStateToBlackjack();
    HandState SetHandStateToBust();
    HandState SetHandStateToLive();
    HandState SetHandStateToStand();
    HandState SetHandStateToSurrendered();
    HandState SetHandStateToResolved();
    public int CalculateHandValue();
    public int GetCardCount();
}