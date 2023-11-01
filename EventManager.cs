public class EventManager
{
    private List<Action<Event>> _subscribers;
    public List<Action<Event>> Subscribers
    {
        get { return _subscribers; }
    }

    public EventManager()
    {
        _subscribers = new List<Action<Event>>();
    }

    public void AddSubscriber(Action<Event> callback)
    {
        _subscribers.Add(callback);
    }

    public void RemoveSubscriber(Action<Event> callback)
    {
        _subscribers.Remove(callback);
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

    public void OnAbility(Card abilityCard)
    {
        TriggerSubscribers(new AbilityEvent(abilityCard));
    }

    public void OnManaChange(int amount)
    {
        TriggerSubscribers(new ManaEvent(amount));
    }

    public void TriggerSubscribers(Event _event)
    {
        foreach (Action<Event> subscriber in Subscribers)
        {
            subscriber(_event);
        }
    }
}
