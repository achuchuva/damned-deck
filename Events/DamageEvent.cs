using System;

public class DamageEvent
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

    public void AddCard(Card card, int damage)
    {
        _damagedCards.Add(card, damage);
    }
}