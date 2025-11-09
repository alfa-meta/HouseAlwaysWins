using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;


public interface IPlayer
{
    void AddCardToHand(Card card);
    int GetCardCountInHand();
    int GetCardValueInHand();
    Card[] GetAllCards();
    HandState GetHandState();
    HandState EvaluateHandState();
    string SetStartingMoney(string startingMoney);
}