using System;
using SplashKitSDK;

public abstract class Card
{
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

    public Card(int cost, string name, string desc, Bitmap image)
    {
        _cost = cost;
        _name = name;
        _description = desc;
        _image = image;
    }

    public virtual void TakeDamage(int amount) { }

    public virtual void Die() { }

    public virtual void Discard()
    { 
        EventManager.GetInstance().Game.Hand.RemoveCard(this);
        EventManager.GetInstance().Game.Deck.RemoveCard(this);
    }

    public virtual void Heal(int amount) { }

    public virtual void SetMaxHealth(int health) { }

    public abstract void HandleEvent(Event e);

    public void Draw(int x, int y)
    {
        SplashKit.FillRectangle(Color.White, x, y, 150, 250);

        Image.Draw(x, y);

        SplashKit.DrawLine(Color.Black, x, y + 100, x + 150, y + 100);

        SplashKit.DrawText(Name, Color.Black, x, y + 100);

        SplashKit.DrawLine(Color.Black, x, y + 150, x + 150, y + 150);

        SplashKit.DrawText(Description, Color.Black, x, y + 150);

        SplashKit.FillCircle(Color.Yellow, x + 25, y + 25, 25);
        SplashKit.DrawText(Cost.ToString(), Color.Black, x + 15, y + 15);

        SplashKit.FillCircle(Color.Red, x + 125, y + 225, 25);
        SplashKit.DrawText(Cost.ToString(), Color.Black, x + 115, y + 215);
    }
}
