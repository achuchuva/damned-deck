public class EventManager
{
    public static EventManager _manager;
    private List<Card> _subscribers;
    public List<Card> Subscribers
    {
        get { return _subscribers; }
    }
    private Game _game;
    public Game Game
    {
        get { return _game; }
    }

    public EventManager(Game game)
    {
        _game = game;
    }

    public void AddSubscriber(Card card)
    {
        _subscribers.Add(card);
    }

    public void OnDamage(Dictionary<Card, int> damagedCards)
    {
        foreach (KeyValuePair<Card, int> damagedCard in damagedCards)
        {
            damagedCard.Key.TakeDamage(damagedCard.Value);
        }
        DamageEvent _event = new DamageEvent(Game, damagedCards);

        foreach (Card subscriber in Subscribers)
        {
            subscriber.HandleEvent(_event);
        }
    }
}
