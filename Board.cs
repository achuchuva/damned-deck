using System;
using SplashKitSDK;

public class Board
{
    public List<Card> _currentCards;

    public Board()
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
