using System;

public class DeathEvent : Event
{

    private List<Card> _destroyedCards;
    public List<Card> DestroyedCards
    {
        get { return _destroyedCards; }
    }

    public DeathEvent(List<Card> destroyedCards)
    {
        _destroyedCards = destroyedCards;
    }
}