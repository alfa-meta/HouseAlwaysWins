namespace HouseAlwaysWins.Models;


public class Player : IPlayer
{
    public Guid _id { get; private set; }
    public IHand _hand { get;}
    public string _totalBank { get; private set; }
    public string _startingMoney { get; private set; } = "500";

    public Player()
    {
        _id = Guid.NewGuid();
        _hand = new Hand();
        _totalBank = _startingMoney;
    }

    public HandState EvaluateHandState()
    {
        if (_hand._handValue == 0 || _hand.GetCardCount() == 0)
        {
            _hand.SetHandStateToEmpty();
        }

        if (_hand._handValue > 21)
        {
            _hand.SetHandStateToBust();
        }

        if (_hand._handValue == 21 && _hand.GetCardCount() == 2)
        {
            _hand.SetHandStateToBlackjack();
        }
        
        return _hand._handState;   
    }

    public string SetStartingMoney(string startingMoney)
    {
        try
        {
            float floatStartingMoney = float.Parse(startingMoney);
            
            if (floatStartingMoney <= 1.00)
            {
                throw new ArgumentOutOfRangeException(nameof(floatStartingMoney), "Value must be greater than 1.00");
            }

            return startingMoney;
        }
        catch (FormatException)
        {
            // The string is not a number
            return "500";
        }
        catch (OverflowException)
        {
            // Number is too large.
            return "500";
        }
    }
}