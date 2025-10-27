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
    public int CalculateHandValue();
    public int GetCardCount();
}