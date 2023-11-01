using System;

public class AbilityEvent : Event
{
    private Card _abilityCard;
    public Card AbilityCard
    {
        get { return _abilityCard; }
    }

    public AbilityEvent(Card abilityCard)
    {
        _abilityCard = abilityCard;
    }
}