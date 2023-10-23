public class Event
{
    private Game _state;
    public Game State
    {
        get { return _state; }
    }

    public Event(Game state)
    {
        _state = state;
    }
}
