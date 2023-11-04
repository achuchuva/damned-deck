using System;

public class SummonEvent : Event
{
    private Card _summonedCard;
    public Card SummonedCard
    {
        get { return _summonedCard; }
    }

    private int _index;
    public int Index
    {
        get { return _index; }
    }

    public SummonEvent(Card summonedCard, int index)
    {
        _summonedCard = summonedCard;
        _index = index;
    }
}