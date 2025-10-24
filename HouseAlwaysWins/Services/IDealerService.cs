using HouseAlwaysWins.Models;

namespace HouseAlwaysWins.Services;


public interface IDealerService
{
    Queue<Card> CreateFullDeck();
    Queue<Card> CreateEmptyDeck();
    Queue<Card> EmptyDeck(Queue<Card> deck);
    Queue<Card> ShuffleDeck(Queue<Card> deck);
    Card PickACardFromTheTop(Queue<Card> deck);
    Card PickACardFromTheBottom(Queue<Card> deck);
    int NumberOfCardsLeft(Queue<Card> deck);
    void PrintDeck();
    void AssignDeckType();
}