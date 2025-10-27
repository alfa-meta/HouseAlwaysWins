namespace HouseAlwaysWins.Models;



public class Hand
{
    private Guid _handId;
    private Queue<Card> _cardsInHand;
    private int _cardValue;
    private HandState _handState;

    public Hand()
    {
        _handId = Guid.NewGuid();
        _cardsInHand = new Queue<Card>();
        _cardValue = 0;
        _handState = HandState.Empty;
    }
}