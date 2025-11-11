using HouseAlwaysWins.Models;

namespace HouseAlwaysWins.Services;


public interface IBlackjackService
{
    void InitialiseGame();
    void CommenceTurn();
    bool CheckIfGameIsOver();
    Player[] FindTheWinners();
}