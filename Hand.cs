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
        get { return _currentCards; }
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
        EventManager.GetInstance().RemoveSubscriber(card);
    }

    public void Draw(int centreX)
    {
        int totalWidth = CurrentCards.Count * 125;
        int startX = centreX - totalWidth / 2;

        foreach (Card card in CurrentCards)
        {
            if (!card.IsBeingDragged)
            {
                card.X = startX;
                card.Y = 600;
            }
            card.Draw();
            startX += 105;
        }
    }

    public void Update()
    {
        foreach (Card card in CurrentCards)
        {
            card.Update();
        }
    }
}
