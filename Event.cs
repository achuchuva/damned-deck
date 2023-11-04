public enum EventType
{
    None,
    Ability,
    ChooseOne,
    Damage,
    Death,
    Discover,
    Draw,
    Hand,
    Health,
    Mana,
    Play,
    Summon
}

public class Event
{
    private Card? _affectedCard;
    public Card? AffectedCard
    {
        get { return _affectedCard; }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
    }

    private EventType _eventType;
    public EventType EventType
    {
        get { return _eventType; }
    }

    public Event(EventType type, Card affectedCard, int amount = 0)
    {
        _eventType = type;
        _affectedCard = affectedCard;
        _amount = amount;
    }
}
