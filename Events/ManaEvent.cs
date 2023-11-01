using System;

public class ManaEvent : Event
{
    private int _amount;
    public int Amount
    {
        get { return _amount; }
    }

    public ManaEvent(int amount)
    {
        _amount = amount;
    }
}
