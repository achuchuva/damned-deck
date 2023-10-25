using System;
using SplashKitSDK;

public class Board
{
    private List<Card> _currentCards;
    public List<Card> CurrentCards
    {
        get { return _currentCards; }
    }

    public Board()
    {
        _currentCards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        _currentCards.Add(card);
        EventManager.GetInstance().AddSubscriber(card);
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
                card.Y = 150;
            }
            card.Draw();
            startX += 125;
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
