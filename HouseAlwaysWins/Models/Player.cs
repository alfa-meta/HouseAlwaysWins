using HouseAlwaysWins.Services;

namespace HouseAlwaysWins.Models;



public class Player : IPlayer
{
    private readonly ICalculatorService _calculatorService;
    public Guid PlayerId { get; private set; }
    public IHand Hand { get;}
    public string TotalBank { get; private set; }
    public string StartingMoney { get; private set; } = "500";

    public Player(ICalculatorService calculatorService)
    {
        ArgumentNullException.ThrowIfNull(calculatorService);
        _calculatorService = calculatorService;

        PlayerId = Guid.NewGuid();
        Hand = new Hand(_calculatorService);
        TotalBank = StartingMoney;
    }


    public void AddCardToHand(Card card)
    {
        Hand.AddCardToHand(card);
    }
    public int GetCardCountInHand()
    {
        return Hand.GetCardCount();
    }

    public Card[] GetAllCards()
    {
        return Hand.CardsInHand;
    }

    public HandState EvaluateHandState()
    {
        if (Hand.HandValue == 0 || Hand.GetCardCount() == 0)
        {
            Hand.SetHandStateToEmpty();
        }

        if (Hand.HandValue > 21)
        {
            Hand.SetHandStateToBust();
        }

        if (Hand.HandValue == 21 && Hand.GetCardCount() == 2)
        {
            Hand.SetHandStateToBlackjack();
        }

        return Hand.HandState;
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