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

    public void TriggerSubscribers(Event _event)
    {
        foreach (Action<Event> subscriber in Subscribers)
        {
            subscriber(_event);
        }
    }
}
