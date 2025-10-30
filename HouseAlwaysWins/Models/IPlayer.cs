using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;


public interface IPlayer
{
    void AddCardToHand(Card card);
    int GetCardCountInHand();

    Card[] GetAllCards();
    HandState EvaluateHandState();
    string SetStartingMoney(string startingMoney);
}