using System;
using SplashKitSDK;

public abstract class Card
{
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

    private Trigger _triggerType;
    public Trigger Trigger
    {
        get { return _triggerType; }
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

    private double _x;
    public double X
    {
        get { return _x; }
        set { _x = value; }
    }

    private double _y;
    public double Y
    {
        get { return _y; }
        set { _y = value; }
    }

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

    private bool _isBeingDragged = false;
    public bool IsBeingDragged
    {
        get { return _isBeingDragged; }
        set { _isBeingDragged = value; }
    }

    private double _offsetX;
    public double OffsetX
    {
        get { return _offsetX; }
        set { _offsetX = value; }
    }
    private double _offsetY;
    public double OffsetY
    {
        get { return _offsetY; }
        set { _offsetY = value; }
    }

    public Card(int cost, string name, string desc, Effect effectType, Target targetType, Trigger triggerType, Bitmap image)
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
    }

    public virtual void TakeDamage(int amount) { }

    public virtual void Die() { }

    public virtual void Heal(int amount) { }

    public virtual void SetMaxHealth(int health) { }

    public abstract void HandleEvent(Event e, Game game);

    public abstract void HandleEffect(List<Card> targets, Game game);

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
        if (_isBeingDragged)
        {
            _x = SplashKit.MouseX() - _offsetX;
            _y = SplashKit.MouseY() - _offsetY;
        }
        else
        {
            _offsetX = SplashKit.MouseX() - X;
            _offsetY = SplashKit.MouseY() - Y;
        }
    }
}
