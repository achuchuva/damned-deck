using System;

public class DrawEvent : Event
{
    private int _amount;
    public int Amount
    {
        get { return _amount; }
    }

    public DrawEvent(int amount)
    {
        _amount = amount;
    }
}