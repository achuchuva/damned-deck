using System;
using SplashKitSDK;

public abstract class Card
{
    private bool _token;
    public bool Token
    {
        get { return _token; }
    }

    private Effect _effectType;
    public Effect EffectType
    {
        get { return _effectType; }
    }

    private Target _targetType;
    public Target TargetType
    {
        get { return _targetType; }
    }

    private EventType _triggerType;
    public EventType TriggerType
    {
        get { return _triggerType; }
    }

    private List<Event> _effectEvents;
    public List<Event> EffectEvents
    {
        get { return _effectEvents; }
    }

    private int _cost;
    public int Cost
    {
        get { return _cost; }
    }
    private Bitmap _image;
    public Bitmap Image
    {
        get { return _image; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
    }
    private string _description;
    public string Description
    {
        get { return _description; }
    }

    public double X { get;set; }
    public double Y { get;set; }

    private int _width;
    public int Width
    {
        get { return _width; }
    }

    private int _height;
    public int Height
    {
        get { return _height; }
    }

    public bool IsBeingDragged { get; set; }

    public double OffsetX{ get; set; }
    public double OffsetY{ get; set; }

    public Card(int cost, string name, string desc, Effect effectType, Target targetType, EventType triggerType, List<Event> effectEvents, Bitmap image, bool token)
    {
        _cost = cost;
        _name = name;
        _description = desc;
        _effectType = effectType;
        _targetType = targetType;
        _triggerType = triggerType;
        _image = image;
        _width = 100;
        _height = 200;
        _effectEvents = effectEvents;
        _token = token;
    }

    public virtual void TakeDamage(int amount) { }

    public virtual void Die() { }

    public virtual void AddHealth(int health) { }

    public abstract void HandleEvent(Event e, Game game);

    public void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                foreach (Event _event in EffectEvents)
                {
                    Event e = new Event(_event.EventType, card, _event.Amount);
                    game.EventManager.TriggerSubscribers(e);
                }
            }
        }
    }

    public abstract Card Clone();

    public bool IsMouseOver()
    {
        Point2D mousePos = new Point2D();
        mousePos.X = SplashKit.MouseX();
        mousePos.Y = SplashKit.MouseY();
        Rectangle rect = new Rectangle();
        rect.X = X;
        rect.Y = Y;
        rect.Width = 100;
        rect.Height = 200;
        return SplashKit.PointInRectangle(mousePos, rect);
    }

    public void Update()
    {
        if (IsBeingDragged)
        {
            X = SplashKit.MouseX() - OffsetX;
            Y = SplashKit.MouseY() - OffsetY;
        }
        else
        {
            OffsetX = SplashKit.MouseX() - X;
            OffsetY = SplashKit.MouseY() - Y;
        }
    }
}
