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
    }

    public void Draw()
    {
        // Add code to render the cards on the board
        int x = 300; // Adjust as needed
        int y = 650; // Adjust as needed

        foreach (Card card in CurrentCards)
        {
            card.Draw(x, y);
            x += 100; // Adjust spacing between cards
        }
    }
}
