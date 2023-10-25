public class EventManager
{
    public static EventManager _instance = GetInstance();
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

    public EventManager(Game game)
    {
        _subscribers = new List<Card>();
        _game = game;
    }

    public static EventManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new EventManager(new Game(new Board(), new Hand(), new Deck(), 10));
        }
        return _instance;
    }

    public void AddSubscriber(Card card)
    {
        _subscribers.Add(card);
    }

    public void RemoveSubscriber(Card card)
    {
        _subscribers.Remove(card);
    }

    public void OnDamage(Card damagedCard, int amount)
    {
        TriggerSubscribers(new DamageEvent(damagedCard, amount));
    }

    public void OnDeath(Card destroyedCard)
    {
        TriggerSubscribers(new DeathEvent(destroyedCard));
    }

    public void OnDraw(int amount)
    {
        TriggerSubscribers(new DrawEvent(amount));
    }

    public void OnHeal(Card healedCard, int amount)
    {
        TriggerSubscribers(new HealEvent(healedCard, amount));
    }

    public void OnPlay(Card playedCard)
    {
        TriggerSubscribers(new PlayEvent(playedCard));
    }

    public void OnSummon(List<Card> summonedCards)
    {
        TriggerSubscribers(new SummonEvent(summonedCards));
    }

    public void TriggerSubscribers(Event _event)
    {
        foreach (Card subscriber in Subscribers)
        {
            subscriber.HandleEvent(_event);
        }
    }
}
