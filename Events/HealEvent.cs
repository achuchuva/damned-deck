using System;

public class HealEvent : Event
{

    private Dictionary<Card, int> _healedCards;
    public Dictionary<Card, int> HealedCards
    {
        get { return _healedCards; }
    }

    public HealEvent(Dictionary<Card, int> healedCards)
    {
        _healedCards = healedCards;
    }
}