using System;
using SplashKitSDK;

public class Hand
{
    public List<Card> currentCards;

    public Hand()
    {
        currentCards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        currentCards.Add(card);
    }

    public void RemoveCard(Card card)
    {
        currentCards.Remove(card);
    }
}
