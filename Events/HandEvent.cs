using System;

public class HandEvent : Event
{
    private Card _addedCard;
    public Card AddedCard
    {
        get { return _addedCard; }
    }

    public HandEvent(Card addedCard)
    {
        _addedCard = addedCard;
    }
}