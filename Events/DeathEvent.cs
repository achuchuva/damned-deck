using System;

public class DeathEvent : Event
{

    private Card _destroyedCard;
    public Card DestroyedCard
    {
        get { return _destroyedCard; }
    }

    public DeathEvent(Card destroyedCard)
    {
        _destroyedCard = destroyedCard;
    }
}