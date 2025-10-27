namespace HouseAlwaysWins.Models;


public class Player
{
    private Guid _id;
    private Hand _hand;
    private string _totalBank;
    private string _startingMoney = "500";

    public Player(Hand hand)
    {
        _id = Guid.NewGuid();
        _hand = hand;
        _totalBank = _startingMoney;
    }
}