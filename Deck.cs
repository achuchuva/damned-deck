using System;
using SplashKitSDK;

public class Deck
{
    public List<Card> currentCards;

    public Deck()
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

    public Card DrawCard()
    {
        Card card = _currentCards.First();
        RemoveCard(card);
        return card;
    }

    public void Shuffle()
    {

    }
}
