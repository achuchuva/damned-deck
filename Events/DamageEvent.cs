using System;

public class DamageEvent : Event
{

    private Dictionary<Card, int> _damagedCards;
    public Dictionary<Card, int> DamagedCards
    {
        get { return _damagedCards; }
    }

    public DamageEvent(Dictionary<Card, int> damagedCards)
    {
        _damagedCards = damagedCards;
    }
}