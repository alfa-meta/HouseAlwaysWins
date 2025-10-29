using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;


public interface IPlayer
{
    Guid _id { get;}
    Hand _hand { get;}
    string _totalBank { get; }
    string _startingMoney { get; }

    Guid SetGuid();

    string SetStartingMoney(string startingMoney);
}