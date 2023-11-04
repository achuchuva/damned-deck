using System;
using SplashKitSDK;

public class Hand
{
    public const int MAX_CARDS = 10;
    private List<Card> _currentCards;
    public List<Card> CurrentCards
    {
        get { return _currentCards; }
    }

    public Hand()
    {
        _currentCards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        if (_currentCards.Count < Hand.MAX_CARDS)
        {
            _currentCards.Add(card);
        }
    }

    public void RemoveCard(Card card)
    {
        _currentCards.Remove(card);
    }

    public void Update()
    {
        foreach (Card card in CurrentCards)
        {
            card.Update();
        }
    }
}
