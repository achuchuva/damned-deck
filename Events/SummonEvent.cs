using System;

public class SummonEvent : Event
{
    private List<Card> _summonedCards;
    public List<Card> SummonedCards
    {
        get { return _summonedCards; }
    }

    public SummonEvent(List<Card> summonedCards)
    {
        _summonedCards = summonedCards;
    }
}