using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;


public interface IPlayer
{
    HandState EvaluateHandState();
    string SetStartingMoney(string startingMoney);
}