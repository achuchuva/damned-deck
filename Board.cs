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

    public void AddCard(Card card, int index)
    {
        EventManager.GetInstance().AddSubscriber(e => card.HandleEvent(e));
        _currentCards.Insert(index, card);
    }

    public void RemoveCard(Card card)
    {
        EventManager.GetInstance().RemoveSubscriber(e => card.HandleEvent(e));
        _currentCards.Remove(card);
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
