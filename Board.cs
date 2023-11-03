using System;
using SplashKitSDK;

public class Board
{
    public const int MAX_CARDS = 7;
    private List<Card> _currentCards;
    public List<Card> CurrentCards
    {
        get { return _currentCards; }
    }

    public Board()
    {
        _currentCards = new List<Card>();
    }

    public void AddCard(Card card, int index)
    {
        _currentCards.Insert(index, card);
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
