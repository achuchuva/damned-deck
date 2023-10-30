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

    public void DrawCard(Hand hand, int amount)
    {
        if (amount > _currentCards.Count)
        {
            amount = _currentCards.Count;
        }
        List<Card> cardsToDraw = _currentCards.GetRange(0, amount);
        foreach (Card card in cardsToDraw)
        {
            if (hand.CurrentCards.Count < hand.MaxCards)
            {
                hand.AddCard(card);
            }
        }
        _currentCards.RemoveRange(0, amount);
    }

    public void Shuffle()
    {

    }

    public void Draw()
    {
        if (CurrentCards.Count > 0)
        {
            SplashKit.FillRectangle(Color.White, 1115, 400, 35, 150);
        }
    }

}
