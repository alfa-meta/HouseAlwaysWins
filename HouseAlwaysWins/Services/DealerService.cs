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

    /*
    *   The following algorithm is split into two parts.
    *   Check if seed is bigger than 0 if it is then the deck will always be shuffled
    *   in the same order.
    *   The shuffling uses Fisher-Yates shuffle algorithm.
    *   
    */
    public Queue<Card> ShuffleDeck(Queue<Card> deck, int seed)
    {
        Random rng;

        if (seed > 0)
        {
            rng = new Random(seed); // Seed determined shuffle.
        } else
        {
            rng = new Random(); // Undeterministic randomness
        }

        Card[] shuffleDeckArray = deck.ToArray();

        for (int i = shuffleDeckArray.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1); // random index from 0 to 1
            (shuffleDeckArray[i], shuffleDeckArray[j]) = (shuffleDeckArray[j], shuffleDeckArray[i]); // swap
        }

        deck = new Queue<Card>(shuffleDeckArray);
    
        return deck;
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