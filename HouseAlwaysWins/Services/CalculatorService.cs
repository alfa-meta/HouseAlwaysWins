using HouseAlwaysWins.Models;


namespace HouseAlwaysWins.Services;


public class CalculatorService : ICalculatorService
{
    public int EvaluateHand(IHand hand)
    {
        int handValue = 0;
        int numberOfAces = 0;

        foreach (Card card in hand._cardsInHand)
        {
            switch (card.rank)
            {
                case Rank.Ace:
                    handValue += 11;
                    numberOfAces += 1;
                    break;
                case Rank.King:
                    handValue += 10;
                    break;
                case Rank.Queen:
                    handValue += 10;
                    break;
                case Rank.Jack:
                    handValue += 10;
                    break;
                default:
                    handValue += (int)card.rank + 1;
                    break;
            }
        }

        for (int i = 0; numberOfAces > i; i++)
        {
            if (handValue > 21)
            {
                handValue -= 10;
            }
        }

        return handValue;
    }
}