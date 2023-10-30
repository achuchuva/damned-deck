using System;
using SplashKitSDK;

public class Board
{
    private int _maxCards = 7;
    public int MaxCards
    {
        get { return _maxCards; }
    }
    private EventManager _eventManager;
    private List<Card> _currentCards;
    public List<Card> CurrentCards
    {
        get { return _currentCards; }
    }

    public Board(EventManager eventManager)
    {
        _currentCards = new List<Card>();
        _eventManager = eventManager;
    }

    public void AddCard(Card card, int index)
    {
        Console.WriteLine("In Board.AddCard. Going to add " + card.Name);
        PrintCards();
        _currentCards.Insert(index, card);
        PrintCards();
        Console.WriteLine("Added card");
    }

    public void PrintCards()
    {
        foreach (Card card in CurrentCards)
        {
            Console.Write(card.Name + ",");
        }
        Console.WriteLine("");
    }

    public void RemoveCard(Card card)
    {
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
