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

    public Minion(int cost, string name, string desc, Bitmap image, int health) : base(cost, name, desc, image)
    {
        _health = health;
        _maxHealth = health;
    }

    public override void Play(bool isLeft)
    {
        if (isLeft)
        {
            EventManager.GetInstance().Game.Board.CurrentCards.Insert(0, this);
        }
        else
        {
            EventManager.GetInstance().Game.Board.AddCard(this);
        }
        base.Play(isLeft);
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
        EventManager.GetInstance().Game.Board.RemoveCard(this);
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

    public override void HandleEvent(Event _event) { }
}
