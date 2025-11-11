using HouseAlwaysWins.Models;

namespace HouseAlwaysWins.Services;


public interface ICalculatorService
{
    int EvaluateHand(IHand hand);
    Player[] EvaluateWinner(Player[] listOfPlayers);
}