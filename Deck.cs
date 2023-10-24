using System;
using SplashKitSDK;

public class Deck
{
    private List<Card> _currentCards;
    public List<Card> CurrentCards
    {
        get { return _currentCards; }
    }

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

    public void DrawCard(int amount)
    {
        if (amount > _currentCards.Count)
        {
            amount = _currentCards.Count;
        }
        _currentCards.RemoveRange(0, amount);
        Hand hand = EventManager.GetInstance().Game.Hand; 
        foreach (Card card in hand.CurrentCards)
        {
            if (hand.CurrentCards.Count < hand.MaxCards)
            {
                EventManager.GetInstance().Game.Hand.AddCard(card);
            }
            else
            {
                card.Discard();
            }
        }
    }

    public void Shuffle()
    {

    }
}
