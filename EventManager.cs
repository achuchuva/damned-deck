public class EventManager
{
    public static EventManager _instance;
    private List<Card> _subscribers;
    public List<Card> Subscribers
    {
        get { return _subscribers; }
    }
    private Game _game;
    public Game Game
    {
        get { return _game; }
        set { _game = value; }
    }

    public EventManager()
    {

    }

    public static EventManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new EventManager();
        }
        return _instance;
    }

    public void AddSubscriber(Card card)
    {
        _subscribers.Add(card);
    }

    public void OnPlay(Card playedCard)
    {
        PlayEvent _event = new PlayEvent(playedCard);

        foreach (Card subscriber in Subscribers)
        {
            subscriber.HandleEvent(_event);
        }
    }

    public void OnDamage(Dictionary<Card, int> damagedCards)
    {
        foreach (KeyValuePair<Card, int> damagedCard in damagedCards)
        {
            damagedCard.Key.TakeDamage(damagedCard.Value);
        }
        DamageEvent _event = new DamageEvent(damagedCards);

        foreach (Card subscriber in Subscribers)
        {
            subscriber.HandleEvent(_event);
        }
    }
}
