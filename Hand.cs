using System;
using SplashKitSDK;

public class Hand
{
    private int _maxCards = 10;
    public int MaxCards
    {
        get { return _maxCards; }
    }

    private List<Card> _currentCards;
    public List<Card> CurrentCards
    {
        get { return CurrentCards; }
    }

    public Hand()
    {
        _currentCards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        _currentCards.Add(card);
    }

    public void RemoveCard(Card card)
    {
        _currentCards.Remove(card);
    }
}
