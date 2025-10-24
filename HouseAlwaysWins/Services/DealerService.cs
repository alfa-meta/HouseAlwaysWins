using HouseAlwaysWins.Models;


namespace HouseAlwaysWins.Services;

public class DealerService : IDealerService
{
    public Queue<Card> CreateFullDeck()
    {
        Queue<Card> FullDeck = new Queue<Card>();
        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                FullDeck.Enqueue(new Card(s, r));
            }
        }

        return FullDeck;
    }

    public Queue<Card> CreateEmptyDeck()
    {
        Queue<Card> EmptyDeck = new Queue<Card>();
        return EmptyDeck;
    }

    public Queue<Card> EmptyDeck(Queue<Card> deck)
    {
        deck.Clear();
        return deck;
    }

    public Queue<Card> ShuffleDeck(Queue<Card> deck)
    {
        throw new NotImplementedException();
    }

    public Card PickACardFromTheTop(Queue<Card> deck)
    {
        Card pickedCard = deck.Dequeue();
        return pickedCard;
    }

    public Card PickACardFromTheBottom(Queue<Card> deck)
    {
        Card pickedCard = deck.Last();
        return pickedCard;
    }

    public void AssignDeckType()
    {
        throw new NotImplementedException();
    }

    public int NumberOfCardsLeft(Queue<Card> deck)
    {
        throw new NotImplementedException();
    }

    public void PrintDeck()
    {
        throw new NotImplementedException();
    }
}