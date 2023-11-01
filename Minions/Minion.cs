using SplashKitSDK;

public class Minion : Card
{
    private int _health;
    public int Health
    {
        get { return _health; }
    }

    private int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
    }

    private bool _hasDied = false;
    public bool HasDied
    {
        get { return _hasDied; }
    }

    public Minion(int cost, string name, string desc, Effect effectType, Target targetType, Trigger triggerType, Bitmap image, int health) : base(cost, name, desc, effectType, targetType, triggerType, image)
    {
        _health = health;
        _maxHealth = health;
    }

    public override void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        _hasDied = true;
    }

    public override void Heal(int amount)
    {
        if (_health < _maxHealth)
        {
            _health = Math.Max(_health + amount, MaxHealth);
        }
    }

    public override void SetMaxHealth(int health)
    {
        _maxHealth = MaxHealth;
    }

    public override void HandleEvent(Event _event, Game game) { }

    public override void Draw()
    {
        base.Draw();
        SplashKit.FillCircle(Color.Red, X + Width, Y + Height, 10);
        SplashKit.DrawText(Health.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 12, X + Width - 3, Y + Height - 6);
    }
}
