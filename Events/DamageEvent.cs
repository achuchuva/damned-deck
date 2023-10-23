using System;

public class DamageEvent : Event
{

    private Card _damagedCard;
    public Card DamagedCard
    {
        get { return _damagedCard; }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
    }

    public DamageEvent(Card damagedCard, int amount)
    {
        _damagedCard = damagedCard;
        _amount = amount;
    }
}