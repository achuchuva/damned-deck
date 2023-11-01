using System;
using SplashKitSDK;

public enum EffectType
{
    None,
    Mana,
    Damage,
    Draw,
    Destroy
}

public enum TargetType
{
    None,
    Self,
    Random,
    All,
    AllButSelf,
    Chosen
}

public enum TriggerType
{
    None,
    OnPlay,
    OnDeath,
    OnAbility,
    OnDamage
}

public abstract class Card
{
    private EffectType _effectType;
    public EffectType EffectType
    {
        get { return _effectType; }
    }

    private TargetType _targetType;
    public TargetType TargetType
    {
        get { return _targetType; }
    }

    private TriggerType _triggerType;
    public TriggerType TriggerType
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

    public Card(int cost, string name, string desc, EffectType effectType, TargetType targetType, TriggerType triggerType, Bitmap image)
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

    public virtual void Draw()
    {
        SplashKit.FillRectangle(Color.White, X, Y, Width, Height);
        Image.Draw(X, Y);

        SplashKit.DrawLine(Color.Black, X, Y + (Height / 3), X + Width, Y + (Height / 3));

        DrawMultilineText(Name, "Fonts/Roboto-Regular.ttf", Color.Black, (int)X + 5, (int)Y + (Height / 3) + 5, 100, 12);

        SplashKit.DrawLine(Color.Black, X, Y + (Height / 2), X + Width, Y + (Height / 2));

        DrawMultilineText(Description, "Fonts/Roboto-Thin.ttf", Color.Black, (int)X + 5, (int)Y + (Height / 2) + 5, 100, 12);

        SplashKit.DrawRectangle(Color.Black, X, Y, Width, Height);

        SplashKit.FillCircle(Color.Yellow, X, Y, 10);
        SplashKit.DrawText(Cost.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 12, X - 3, Y - 6);
    }

    private void DrawMultilineText(string text, string font, Color color, int x, int y, int maxWidth, int lineHeight)
    {
        List<string> lines = SplitTextIntoLines(text, maxWidth);
        int lineY = y;

        foreach (string line in lines)
        {
            SplashKit.DrawText(line, color, font, 12, x, lineY);
            lineY += lineHeight;
        }
    }

    private List<string> SplitTextIntoLines(string text, int maxWidth)
    {
        List<string> lines = new List<string>();
        string[] words = text.Split(' ');
        string currentLine = "";

        foreach (string word in words)
        {
            if (SplashKit.TextWidth(currentLine + " " + word, "Fonts/Roboto-Thin.ttf", 15) <= maxWidth)
            {
                currentLine += (currentLine == "" ? "" : " ") + word;
            }
            else
            {
                lines.Add(currentLine);
                currentLine = word;
            }
        }

        if (!string.IsNullOrEmpty(currentLine))
        {
            lines.Add(currentLine);
        }

        return lines;
    }

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
