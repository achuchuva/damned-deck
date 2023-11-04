using System;

public class DiscoverEvent : Event
{
    private Card _discoveredCard;
    public Card DiscoveredCard
    {
        get { return _discoveredCard; }
    }

    public DiscoverEvent(Card discoveredCard)
    {
        _discoveredCard = discoveredCard;
    }
}