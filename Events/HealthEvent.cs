using System;

public class HealthEvent : Event
{

    private Card _healthCard;
    public Card HealthCard
    {
        get { return _healthCard; }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
    }

    public HealthEvent(Card healthCard, int amount)
    {
        _healthCard = healthCard;
        _amount = amount;
    }
}