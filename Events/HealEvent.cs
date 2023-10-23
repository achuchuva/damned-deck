using System;

public class HealEvent : Event
{

    private Card _healedCard;
    public Card HealedCard
    {
        get { return _healedCard; }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
    }

    public HealEvent(Card healedCard, int amount)
    {
        _healedCard = healedCard;
        _amount = amount;
    }
}