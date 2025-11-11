using HouseAlwaysWins.Models;

namespace HouseAlwaysWins.Services;

public interface IGameService
{
    void PlayGameBlackJack(IBlackjackService blackjackService);
}